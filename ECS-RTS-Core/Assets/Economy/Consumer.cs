using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Entities;
using UnityEngine;
using Unity.Burst;
using Unity.Collections;

public struct Consumer : ISharedComponentData
{
    public string name;
    public string description;
    public ResourceAmountPair[] consumption;
}

public struct ConsumerInstance : IComponentData
{
    public Vector2 position;
    public ResourceAmountPair[] suppliers;
}

[BurstCompile]
public struct ConsumerInstanceUpdater : IJobProcessComponentData<Consumer, ConsumerInstance>
{
    public PlayerData player;
    public GameState gameState;

    public void Execute([ReadOnly] ref Consumer consumer, ref ConsumerInstance instance)
    {
        
    }
}