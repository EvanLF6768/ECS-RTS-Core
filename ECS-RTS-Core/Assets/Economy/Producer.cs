using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Entities;
using UnityEngine;

public class Producer : IComponentData, IDeleteable
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

    public float speedCap;
    public float logisticsPenilty;
    public Vector2Int position;
    public ResourceAmountSatisfactionGroupConsumer[] resources;
    public Pair<ushort, float>[] productionBase;
    public Pair<ushort, float>[] boosts;
}