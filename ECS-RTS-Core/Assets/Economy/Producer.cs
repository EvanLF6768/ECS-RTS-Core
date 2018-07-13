using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Entities;
using UnityEngine;

public class Producer : ISharedComponentData
{
    public string name;
    public string description;
    public Producer[] production;
}

public struct ProducerInstance : IComponentData
{
    public Vector2 position;
    public ResourceAmountPair[] customers;
}