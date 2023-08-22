using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Getx3_But : MonoBehaviour, IPointerDownHandler
{
    private int random;
    private void OnEnable()
    {
        if (Wardrobe.Players_Gifts.Count > 0) random = 1;
        else random = 0;
    }
    private void Start()
    {
        if (!Advertisement.isInitialized)
        {
            if (Advertisement.isSupported) Advertisement.Initialize("3742183", false);
        }
        if (random == 0) GetComponent<Image>().sprite = Resources.Load<Sprite>("Get_x3"); ;
        if (random == 1) GetComponent<Image>().sprite = Resources.Load<Sprite>("Get_x3+gift");
    }

    public string myPlacementId = "rewardedVideo";
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Advertisement.IsReady(myPlacementId))
        {

            CrystalsScript.crystals += CrystalsScript.crystals_game * 3;
            CrystalsScript.crystals_game = 0;

            if (random == 1)
            {
                Gift.On_Gift = true;
                MenuControls.Gift_.SetActive(true);
                MenuControls.MainMenu.SetActive(false);
                MenuControls.Done.SetActive(false);
            }
            else
            {
                MenuControls.MainMenu.SetActive(true);
                MenuControls.Done.SetActive(false);
            }

            Ad.ad = true;

            Advertisement.Show(myPlacementId);
        }
    }

}
