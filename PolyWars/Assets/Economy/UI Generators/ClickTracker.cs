using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickTracker : MonoBehaviour
{
    public new Camera camera;

	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            if (!Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit)) return;
            var generator = hit.transform.gameObject.GetComponent<UIGenerator>();
            if (generator == null) return;
            generator.Generate();
        }
	}
} 