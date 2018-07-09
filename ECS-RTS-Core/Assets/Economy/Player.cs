using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;

[System.Serializable]
public struct PlayerData : IComponentData
{
    public float PathFind(Vector2Int start, Vector2Int end)
    {
        throw new System.NotImplementedException();
    }

    public FastList<DeleteableStructReference<Booster>> Boosters;
    public FastList<DeleteableStructReference<Producer>> Producers;
    public FastList<DeleteableStructReference<Consumer>> Consumers;
    public TerrainTile[,] Terrain;
    public float[] resources; // Index must match with resource ID
    public float[] income; // Index must match with resource ID
}

public class PlayerUpdateSystem : JobComponentSystem
{
    [BurstCompile]
    struct PlayerUpdater : IJobProcessComponentData<PlayerData>
    {
        public void Execute(ref PlayerData player)
        {
            int _maxAmountOfObjectsToUpdate = 24;
            int _amountOfConsumersToUpdate = math.max(_maxAmountOfObjectsToUpdate, player.Consumers.Length);
        }
    }
}