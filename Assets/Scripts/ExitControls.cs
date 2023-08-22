using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ExitControls : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player_Game"))
        {
            CrystalsScript.crystals_game += 10;
            Get_wi.timer_get_wi = 0;
            SceneManager.LoadScene("Menu");
        }
    }

}
