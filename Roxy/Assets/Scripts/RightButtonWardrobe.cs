using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Linq;

public class RightButtonWardrobe : Wardrobe, IPointerDownHandler
{
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
                ForWardRobe();
    }

}
