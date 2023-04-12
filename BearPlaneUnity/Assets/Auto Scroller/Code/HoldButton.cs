using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Bear bear;

    void Awake()
    {
        bear = FindObjectOfType<Bear>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        bear.Roar();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //bear.shouldThrust = false;
    }
}
