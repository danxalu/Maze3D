using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Get_nt_But : MonoBehaviour, IPointerDownHandler//, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        MenuControls.Gift_.SetActive(false);
        MenuControls.MainMenu.SetActive(true);
        Gift.On_Gift = false;
        SaveLoad.SaveGame();
    }
}
