using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public void TurnOnOff()
    {
        if (Music.Music_On && !GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();
        if (!Music.Music_On && GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Stop();
    }
}
