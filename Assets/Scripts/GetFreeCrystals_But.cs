using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GetFreeCrystals_But : MonoBehaviour, IPointerDownHandler
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

            CrystalsScript.crystals += 150;

            Ad.ad = true;

            Advertisement.Show(myPlacementId);
        }
    }
}
