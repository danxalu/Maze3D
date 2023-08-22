using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControls : MonoBehaviour
{
    public static GameObject MainMenu;
    public static GameObject Settings;
    public static GameObject Wardrobe;
    public static GameObject Done;
    public static GameObject Gift_;
    public static GameObject Load;
    [SerializeField] private GameObject Music_;

    static public float timer_get_wi;

    static public bool Done_;
    public static void MenuVar()
    {
        MainMenu = GameObject.Find("MainMenu");
        Wardrobe = GameObject.Find("Wardrobe_");
        Settings = GameObject.Find("Settings_");
        Done = GameObject.Find("Done_");
        Gift_ = GameObject.Find("Gift_");
        Load = GameObject.Find("Load_");
    }
    private void Start()
    {
        LoadData.LoadGame();
        MenuVar();
        if (Done_)
        {
            MainMenu.SetActive(false);
            Wardrobe.SetActive(false);
            Settings.SetActive(false);
            Gift_.SetActive(false);
            Load.SetActive(false);
            Done.SetActive(true);
        }
        else if(Gift.On_Gift)
        {
            MainMenu.SetActive(false);
            Wardrobe.SetActive(false);
            Settings.SetActive(false);
            Done.SetActive(false);
            Load.SetActive(false);
            Gift_.SetActive(true);
        }
        else
        {
            Wardrobe.SetActive(false);
            Settings.SetActive(false);
            Gift_.SetActive(false);
            Done.SetActive(false);
            Load.SetActive(false);
            MainMenu.SetActive(true);
        }

        if (Music.Music_On && !Music_.GetComponent<AudioSource>().isPlaying) Music_.GetComponent<AudioSource>().Play();
        if (!Music.Music_On && Music_.GetComponent<AudioSource>().isPlaying) Music_.GetComponent<AudioSource>().Stop();
    }
}