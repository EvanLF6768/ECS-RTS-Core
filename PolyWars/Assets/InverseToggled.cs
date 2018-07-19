using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InverseToggled : MonoBehaviour
{
    void Update()
    {
        obj.enabled = !toggle.isOn;
    }

    public Toggle toggle;
    public MonoBehaviour obj;
}