using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct ResourceAmountSatisfactionGroupConsumer
{
    public ushort resource;
    public float amount;
    public LinkedList<SatisfactionLinkConsumer> satisfactionLinks;
}

public struct ResourceAmountSatisfactionGroupProducer
{
    public ushort resource;
    public float amount;
    public LinkedList<SatisfactionLinkProducer> satisfactionLinks;
}