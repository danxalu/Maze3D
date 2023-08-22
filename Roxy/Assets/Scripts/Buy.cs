using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Buy : MonoBehaviour, IPointerDownHandler//, IPointerUpHandler
{
    public GameObject Player_1;
    public GameObject Player_2;
    public GameObject Player_3;
    public GameObject Player_4;
    public GameObject Player_5;
    public GameObject Player_6;
    public GameObject Player_7;
    public GameObject Player_8;
    public GameObject Player_9;
    public GameObject Player_10;
    public GameObject Player_11;
    public GameObject Player_12;
    public GameObject Player_13;
    public GameObject Player_14;
    public GameObject Player_15;
    private void Update()
    {
        if (CrystalsScript.crystals >= 750 && Wardrobe.Players_Shop.Count > 0) GetComponent<Image>().color = new Color(1, 1, 1, 1);
        else GetComponent<Image>().color = new Color(1, 1, 1, 0.33f);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (CrystalsScript.crystals >= 750 && Wardrobe.Players_Shop.Count > 0)
        {
            int indexPlayer = Random.Range(0, Wardrobe.Players_Shop.Count);
            CrystalsScript.crystals -= 750;
            Wardrobe.Players.Add(Wardrobe.Players_Shop[indexPlayer]);
            Wardrobe.Players_Shop.Remove(Wardrobe.Players_Shop[indexPlayer]);
            PlayerWardrobe(Wardrobe.Players.ElementAt(Wardrobe.Players.Count-1));
            if(Sounds.Sounds_On) GetComponent<AudioSource>().Play();
            SaveLoad.SaveGame();
        }
    }

    public void PlayerWardrobe(GameObject player)
    {
        Player_1.SetActive(false);
        Player_2.SetActive(false);
        Player_3.SetActive(false);
        Player_4.SetActive(false);
        Player_5.SetActive(false);
        Player_6.SetActive(false);
        Player_7.SetActive(false);
        Player_8.SetActive(false);
        Player_9.SetActive(false);
        Player_10.SetActive(false);
        Player_11.SetActive(false);
        Player_12.SetActive(false);
        Player_13.SetActive(false);
        Player_14.SetActive(false);
        Player_15.SetActive(false);

        Wardrobe.Player = player;
        Wardrobe.Player.SetActive(true);
    }
}
