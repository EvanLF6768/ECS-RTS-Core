using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Collections;
using System.Linq;

[System.Serializable]
public struct PlayerData : IComponentData
{
    public float PathFind(Vector2Int start, Vector2Int end)
    {
        throw new System.NotImplementedException();
    }

    public void GenerateDistanceMap(Vector2Int position)
    {

    }

    public float GetPathFindingDistance(Vector2Int position)
    {
        return pathFindingTemp[position.x, position.y];
    }

    public float GetSatisfactionEfficiency(float distance) // GetSatisfactionEfficiency'(distance) > 0 { distance > 0}
    {
        return -1 / distance;
    }

    public void SortByPathfindingDistance(int[] consumerReferences, int left = 0, int right = -1)
    {
        if (right == -1) right = consumerReferences.Length - 1;
        int i = left, j = right;
        float pivot = (GetPathFindingDistance(consumers[consumerReferences[left / 2]].position) + 
            GetPathFindingDistance(consumers[consumerReferences[(left + right) / 2]].position) + 
            GetPathFindingDistance(consumers[consumerReferences[right]].position)) / 3;

        while (i <= j)
        {
            while (GetPathFindingDistance(consumers[consumerReferences[i]].position) < pivot)
            {
                i++;
            }

            while (consumerReferences[j].CompareTo(pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                int tmp = consumerReferences[i];
                consumerReferences[i] = consumerReferences[j];
                consumerReferences[j] = tmp;

                i++;
                j--;
            }
        }

        if (left < j)
        {
            SortByPathfindingDistance(consumerReferences, left, j);
        }

        if (i < right)
        {
            SortByPathfindingDistance(consumerReferences, i, right);
        }
    }

    public FastList<Booster> boosters;
    public FastList<Producer> producers;
    public FastList<Consumer> consumers;
    public float[] resources; // Index must match with resource ID
    public float[] income; // Index must match with resource ID

    private float[,] pathFindingTemp;
}

public class PlayerUpdateSystem : JobComponentSystem
{
    struct SourceResourceAmountGroup
    {
        public SourceResourceAmountGroup(int source, int resource, float amount)
        {
            this.source = source;
            this.resource = resource;
            this.amount = amount;
        }

        public int source;
        public int resource;
        public float amount;
    }

    [BurstCompile]
    struct PlayerUpdater : IJobProcessComponentData<PlayerData, GameState>
    {
        public void Execute(ref PlayerData player, [ReadOnly]ref GameState gameState)
        {
            for (int i = 0; i < 24; i++)
            {
                var current = player.producers.Next();
                player.GenerateDistanceMap(current.position);
                var possibleConnections = new LinkedList<int>();
                for (int j = 0; j < player.consumers.Length; j++)
                {
                    var consumer = player.consumers.Next();
                    int k = 0, l = 0;

                    while (k < consumer.resources.Length)
                    {
                        while (l < current.resources.Length)
                        {
                            if (consumer.resources[k].resource == current.resources[l].resource) goto FND0;
                            l++;
                        }
                        k++;
                    }

                    FND0:
                    var satisfactionLinks = consumer.resources[k].satisfactionLinks;
                    var amount = consumer.resources[k].amount;
                    var currentLink = satisfactionLinks.First;
                    do
                    {
                        if (currentLink.Value.provider == current)
                        {
                            satisfactionLinks.Remove(currentLink);
                            continue;
                        }
                        amount -= currentLink.Value.amount;
                        if (amount < 0.01f) goto FAIL;
                        currentLink = currentLink.Next;
                    } while (currentLink != satisfactionLinks.Last);

                    possibleConnections.AddFirst(j);
                    FAIL:;
                }

                var sortedConnections = possibleConnections.ToArray();
                player.SortByPathfindingDistance(sortedConnections);
                float satisfactionSum = 0;
                float consumptionSum = 0;
                for (int r = 0; r < current.resources.Length; r++)
                {
                    float amountLeftToSatisfy = current.resources[r].amount;
                    for (int j = 0; j < sortedConnections.Length; j++)
                    {
                        var consumer = player.consumers[sortedConnections[j]];
                        for (int s = 0; s < consumer.resources.Length; s++)
                        {
                            if (current.resources[r].resource == consumer.resources[s].resource)
                            {
                                var efficiency = player.GetSatisfactionEfficiency(player.GetPathFindingDistance(consumer.position));
                                if (current.resources[r].amount < amountLeftToSatisfy)
                                {
                                    current.resources[r].satisfactionLinks.AddFirst(new SatisfactionLinkConsumer(consumer, consumer.resources[s].amount, efficiency));
                                    amountLeftToSatisfy -= current.resources[r].amount;
                                    satisfactionSum += efficiency * current.resources[r].amount;
                                    consumptionSum += current.resources[r].amount;
                                    break;
                                }
                                else
                                {
                                    current.resources[r].satisfactionLinks.AddFirst(new SatisfactionLinkConsumer(consumer, amountLeftToSatisfy, efficiency));
                                    satisfactionSum += efficiency * amountLeftToSatisfy;
                                    consumptionSum += amountLeftToSatisfy;
                                    goto SATISFIED;
                                }
                            }
                        }
                    }
                    SATISFIED:;
                }
                current.logisticsPenilty = satisfactionSum / consumptionSum;
            }
        }
    }
}