using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wardrobe : MonoBehaviour
{
   static public GameObject Player;
   static public List<GameObject> Players;
   static public List<GameObject> Players_Shop;
   static public List<GameObject> Players_Gifts;
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

    [SerializeField] private GameObject LeftButton;
    [SerializeField] private GameObject RightButton;

    [SerializeField] private float speedRotate = 25;

    private void OnEnable()
    {
        if(Gift.On_Gift)
        {
            PlayerWardrobe(Players.ElementAt(Players.Count - 1));
            Gift.On_Gift = false;
        }
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu" && CompareTag("Player") && Player == null)
        {

            Players_Gifts = new List<GameObject>
            {   Player_3,
                Player_5,
                Player_7,
                Player_8,
                Player_10,
                Player_11,
                Player_12,
                Player_13,
                Player_15
            };

            Players_Shop = new List<GameObject>
            {   Player_2,
                Player_4,
                Player_6,
                Player_9,
                Player_14
            };

            Players = new List<GameObject> {Player_1};
            PlayerWardrobe(Players.ElementAt(0));
        }
        else
        {
            PlayerWardrobe(Players.ElementAt(Players.IndexOf(Player)));
        }

    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Menu" && CompareTag("Player") && Player != null) PlayerWardrobe(Player);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (Players.IndexOf(Player) == 0) LeftButton.SetActive(false);
            else LeftButton.SetActive(true);

            if (Players.IndexOf(Player) == Players.Count - 1) RightButton.SetActive(false);
            else RightButton.SetActive(true);

            if (CompareTag("Player"))
            {
                transform.Rotate(Vector3.up * speedRotate * Time.deltaTime, Space.Self);
                transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime, Space.Self);
                transform.Rotate(Vector3.left * speedRotate * Time.deltaTime, Space.Self);
            }
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

        Player = player;
        Player.SetActive(true);
    }

    public void BackWardRobe()
    {
        int indexPlayer = Players.IndexOf(Player)-1;
        PlayerWardrobe(Players[indexPlayer]);
        Players[indexPlayer + 1].SetActive(false);
    }

    public void ForWardRobe()
    {
        int indexPlayer = Players.IndexOf(Player)+1;
        PlayerWardrobe(Players[indexPlayer]);
    }
}
