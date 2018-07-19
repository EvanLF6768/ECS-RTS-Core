using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void Update()
    {
        if (isMouseOver)
        {
            hoverTimeCountDown -= Time.deltaTime;
        }

        if (hoverTimeCountDown < 0)
        {
            element.SetActive(true);
            element.transform.position = Input.mousePosition;
            Cursor.SetCursor(new Texture2D(1, 1), new Vector2(0, 0), CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(null, new Vector2(0, 0), CursorMode.Auto);
            element.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverTimeCountDown = hoverTimeToShow;
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }
    
    public bool isMouseOver;
    public float hoverTimeToShow;
    public float hoverTimeCountDown;
    public GameObject element;
}