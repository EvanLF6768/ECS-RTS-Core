using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{    
    public Button button;
    public GameObject parent;

	void Start ()
    {
        button.onClick.AddListener(OnPressed);
	}

    void OnPressed()
    {
        Destroy(parent);
    }
}
