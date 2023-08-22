using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour, IPointerDownHandler//, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        SaveLoad.SaveGame();
        MenuControls.Done_ = true;
        MenuControls.MainMenu.SetActive(true);
        MenuControls.Wardrobe.SetActive(true);
        MenuControls.Settings.SetActive(true);
        MenuControls.Gift_.SetActive(true);
        MenuControls.Done.SetActive(true);
        MenuControls.Load.SetActive(true);
        SceneManager.LoadScene("Game");
    }
}
