using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

public unsafe struct Player
{
    public byte[][] jobAmountPositions;
    public BuildingInstance*[][] jobBuildings;

    public JobPair GetBestJobPair(Vector3 position, float capacity)
    {
        throw new NotImplementedException();
    }
}