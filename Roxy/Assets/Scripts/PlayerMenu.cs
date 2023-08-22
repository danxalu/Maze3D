using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] private float speedRotate = 25;

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

        if (Wardrobe.Player.name == "Player_1") Player_1.SetActive(true);
        else if (Wardrobe.Player.name == "Player_2") Player_2.SetActive(true);
        else if (Wardrobe.Player.name == "Player_3") Player_3.SetActive(true);
        else if (Wardrobe.Player.name == "Player_4") Player_4.SetActive(true);
        else if (Wardrobe.Player.name == "Player_5") Player_5.SetActive(true);
        else if (Wardrobe.Player.name == "Player_6") Player_6.SetActive(true);
        else if (Wardrobe.Player.name == "Player_7") Player_7.SetActive(true);
        else if (Wardrobe.Player.name == "Player_8") Player_8.SetActive(true);
        else if (Wardrobe.Player.name == "Player_9") Player_9.SetActive(true);
        else if (Wardrobe.Player.name == "Player_10") Player_10.SetActive(true);
        else if (Wardrobe.Player.name == "Player_11") Player_11.SetActive(true);
        else if (Wardrobe.Player.name == "Player_12") Player_12.SetActive(true);
        else if (Wardrobe.Player.name == "Player_13") Player_13.SetActive(true);
        else if (Wardrobe.Player.name == "Player_14") Player_14.SetActive(true);
        else if (Wardrobe.Player.name == "Player_15") Player_15.SetActive(true);

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            transform.Rotate(Vector3.up * speedRotate * Time.deltaTime, Space.Self);
            transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime, Space.Self);
            transform.Rotate(Vector3.left * speedRotate * Time.deltaTime, Space.Self);
        }
    }
}