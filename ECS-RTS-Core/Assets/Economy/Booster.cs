﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Entities;
using UnityEngine;

public struct Booster : IComponentData, IDeleteable
{
    public void Delete()
    {
        deleted = true;
    }

    public bool GetDeleted()
    {
        return deleted;
    }

    private bool deleted;

    public Vector2Int position;
    public Pair<int, float>[] effects;
    public Func<float, float> effectMultiplier;
}