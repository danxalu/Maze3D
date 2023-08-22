using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class Buttons : MonoBehaviour, IPointerDownHandler//, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
       if(Sounds.Sounds_On) GetComponent<AudioSource>().Play();
    }
}

