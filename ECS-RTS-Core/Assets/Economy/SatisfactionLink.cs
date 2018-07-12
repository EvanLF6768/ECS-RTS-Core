using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct SatisfactionLinkConsumer
{
    public SatisfactionLinkConsumer(Consumer provider, float amount, float efficiency)
    {
        this.provider = provider;
        this.amount = amount;
        this.efficiency = efficiency;
    }

    public Consumer provider;
    public float amount;
    public float efficiency;
}

public struct SatisfactionLinkProducer
{
    public SatisfactionLinkProducer(Producer provider, float amount, float efficiency)
    {
        this.provider = provider;
        this.amount = amount;
        this.efficiency = efficiency;
    }

    public Producer provider;
    public float amount;
    public float efficiency;
}