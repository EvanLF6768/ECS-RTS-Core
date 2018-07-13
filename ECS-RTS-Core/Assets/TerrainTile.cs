using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Entities;
using UnityEngine;

public struct TerrainTile : ISharedComponentData
{
    public float travelCost;
}