using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
	void Update ()
    {
        text.text = "FPS: " + 1 / Time.deltaTime;
	}

    public Text text;
}
