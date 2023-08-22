using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSounds : MonoBehaviour
{
    public static bool On_Crystal;
    private void Update()
    {
        if (Sounds.Sounds_On && On_Crystal)
        {
            GetComponent<AudioSource>().Play();
            On_Crystal = false;
        }
    }
}
