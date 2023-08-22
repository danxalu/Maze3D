using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackSettings : MonoBehaviour, IPointerDownHandler//, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
       SaveLoad.SaveGame();
       MenuControls.Settings.SetActive(false);
       MenuControls.MainMenu.SetActive(true);
    }



}
