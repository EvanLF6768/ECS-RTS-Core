using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ProgressBarVertical : MonoBehaviour
{
    void Update ()
    {
        if (invertColour)
        {
            bar.color = colourSample.GetPixel((int)((colourSample.width - 1) * (1 - fill)), 0);
        }
        else
        {
            bar.color = colourSample.GetPixel((int)((colourSample.width - 1) * fill), 0);
        }
        bar.rectTransform.offsetMax = new Vector2(bar.rectTransform.offsetMax.x, Mathf.Lerp(-size, 0, fill));
	}

    public Image bar;
    public Texture2D colourSample;
    public float fill;
    public float size;
    public bool invertColour;
}