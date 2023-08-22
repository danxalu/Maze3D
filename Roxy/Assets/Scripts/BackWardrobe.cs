using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackWardrobe : MonoBehaviour, IPointerDownHandler//, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        SaveLoad.SaveGame();
        MenuControls.Wardrobe.SetActive(false);
        MenuControls.MainMenu.SetActive(true);
    }
}
