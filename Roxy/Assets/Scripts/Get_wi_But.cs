using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Get_wi_But : MonoBehaviour, IPointerDownHandler//, IPointerUpHandler
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Done;
    public void OnPointerDown(PointerEventData eventData)
    {
        CrystalsScript.crystals += CrystalsScript.crystals_game;
        Done.SetActive(false);
        MainMenu.SetActive(true);
        CrystalsScript.crystals_game = 0;
        SaveLoad.SaveGame();
    }
}
