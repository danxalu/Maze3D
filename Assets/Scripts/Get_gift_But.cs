using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Get_gift_But : MonoBehaviour, IPointerDownHandler
{
    public string myPlacementId = "rewardedVideo";
    private void Start()
    {

        if (Advertisement.isSupported && !Advertisement.isInitialized)
        {
            Advertisement.Initialize("3742183", false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Advertisement.IsReady(myPlacementId))
        {

            Wardrobe.Players.Add(Gift.Player);
            Wardrobe.Players_Gifts.Remove(Gift.Player);
            MenuControls.MainMenu.SetActive(false);
            MenuControls.Wardrobe.SetActive(true);
            MenuControls.Gift_.SetActive(false);

            Ad.ad = true;

            Advertisement.Show(myPlacementId);
        }
    }
}
