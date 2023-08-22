using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour, IPointerDownHandler//, IPointerUpHandler
{
    static public GameObject MainMenu;
    static public GameObject Settings;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (MenuControls.Settings != null)
        {
            MenuControls.MainMenu.SetActive(false);
            MenuControls.Settings.SetActive(true);
        }

    }
}
