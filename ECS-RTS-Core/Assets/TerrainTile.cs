using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Entities;
using UnityEngine;

public struct TerrainTile : IComponentData
{
    [Serializable]
    public class BaseTile : ScriptableObject
    {
        public Mesh mesh;
        public Material material;
        public float travelCost;
    }

    public enum VisionLevel { None, TerrianOnly, Silhouettes, Full }

    public VisionLevel[] vision;
    public ushort height;
    public ushort tile;
}