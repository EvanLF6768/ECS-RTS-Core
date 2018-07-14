using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Collections;
using System.Linq;

[System.Serializable]
public class PlayerData
{
    public float PathFind(Vector2Int start, Vector2Int end)
    {
        throw new System.NotImplementedException();
    }

    public void GenerateDistanceMap(Vector2Int position, TerrainTile[,] terrain)
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

    public float GetProductionEfficiency(float fulfillment)
    {
        return -1.6f * fulfillment * fulfillment * fulfillment + 2.4f * fulfillment * fulfillment + .2f;
    }

    public float[] resources; // Index must match with resource ID
    public float[] income; // Index must match with resource ID

    private float[,] pathFindingTemp;
}