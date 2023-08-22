using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUItext_crystals : MonoBehaviour
{
    private void Update()
    {
        GetComponent<Text>().text = CrystalsScript.crystals_game.ToString();
    }
}


