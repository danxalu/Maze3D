using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsStart : MonoBehaviour
{
    void OnEnable()
    {
        if (Sounds.Sounds_On) GetComponent<AudioSource>().Play();
    }
}
