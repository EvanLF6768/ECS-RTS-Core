using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Collections;
using System.Linq;

public struct PlayerData : IComponentData
{
    public float PathFind(Vector2Int start, Vector2Int end)
    {
        throw new System.NotImplementedException();
    }

    public float GetSatisfactionEfficiency(float distance) // GetSatisfactionEfficiency'(distance) > 0 { distance > 0}
    {
        return -1 / distance;
    }

    public float GetProductionEfficiency(float fulfillment)
    {
        return -1.6f * fulfillment * fulfillment * fulfillment + 2.4f * fulfillment * fulfillment + .2f;
    }

    public Vector3 resources; // Index must match with resource ID
}