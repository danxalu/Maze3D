using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ad : MonoBehaviour
{
    public static bool ad;
    public string placementId = "banner";

    void Start()
    {
        Advertisement.Initialize("3742183", false);
        StartCoroutine(ShowBanner());
    }

    IEnumerator ShowBanner()
    {
        while(!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementId);
    }

    private void Awake()
    {
        if(!Advertisement.isShowing && ad)
        {
            SaveLoad.SaveGame();
            ad = false;
        }
    }

}
