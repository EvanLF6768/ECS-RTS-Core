using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PureProducerUI : MonoBehaviour
{
	void Start()
    {
        toggle.isOn = producerInstance.operationalOverride;
        title.text = producerInstance.template.name;
        flavourText.text = producerInstance.template.description;
        var resource = producerInstance.template.productionAndCapacity[0].resource;
        resourceImage.sprite = resource.icon;
        textWithBackPlaneGenerator.data = new RichTextElement[] { new RichTextElement(resource.name, -1, "", FontStyle.Bold), new RichTextElement(" | ", -1, "", FontStyle.Normal), new RichTextElement(resource.flavourText, -1, "", FontStyle.Italic) };
        textWithBackPlaneGenerator.Approve();
    }
	
	void Update ()
    {
        producerInstance.operationalOverride = toggle.isOn;
        bar.fill = producerInstance.storedResources[0] / producerInstance.template.productionAndCapacity[0].vector2.y;
	}

    public ProducerInstance producerInstance;
    public ProgressBarVertical bar;
    public Toggle toggle;
    public Text title;
    public Text flavourText;
    public Image resourceImage;
    public TextWithBackPlaneGenerator textWithBackPlaneGenerator;
}