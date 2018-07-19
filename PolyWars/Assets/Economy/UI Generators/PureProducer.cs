using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

public class PureProducer : UIGenerator
{
    public override void Generate()
    {
        var NUI = Instantiate(UI,GameObject.Find("Canvas").transform);
        NUI.GetComponent<PureProducerUI>().producerInstance = producerInstance;
    }

    public GameObject UI;
    public ProducerInstance producerInstance;
}