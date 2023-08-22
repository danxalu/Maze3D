using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WardrobeMenu : MonoBehaviour, IPointerDownHandler//, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (MenuControls.Wardrobe != null)
        {
            MenuControls.MainMenu.SetActive(false);
            MenuControls.Wardrobe.SetActive(true);
        }
    }



}
