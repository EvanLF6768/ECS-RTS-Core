using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct ResourceAmountPair
{
    public ResourceAmountPair(IDGroup resources, float amount)
    {
        this.resources = resources;
        this.amount = amount;
    }

    public IDGroup resources;
    public float amount;
}