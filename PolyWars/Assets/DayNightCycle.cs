using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float dayLength;
    public new Light light;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Rotate(360f * Time.deltaTime / dayLength, 0, 0);
	}
}
