using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Music : MonoBehaviour, IPointerDownHandler//, IPointerUpHandler
{
    private GameObject Music_;
    static public bool Music_On = true;

    private void Awake()
    {
        Music_ = GameObject.Find("Music_");
    }

    private void OnEnable()
    {
        if (Music_On)
        {
            GetComponent<Animator>().Play("Music_On");
        }
        else
        {
            GetComponent<Animator>().Play("Music_Off");
        }
        if (Music.Music_On && !Music_.GetComponent<AudioSource>().isPlaying) Music_.GetComponent<AudioSource>().Play();
        if (!Music.Music_On && Music_.GetComponent<AudioSource>().isPlaying) Music_.GetComponent<AudioSource>().Stop();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Music_On)
        {
            Music_On = false;
            GetComponent<Animator>().Play("Music_Off");
        }
        else
        {
            Music_On = true;
            GetComponent<Animator>().Play("Music_On");
        }
        if (Music.Music_On && !Music_.GetComponent<AudioSource>().isPlaying) Music_.GetComponent<AudioSource>().Play();
        if (!Music.Music_On && Music_.GetComponent<AudioSource>().isPlaying) Music_.GetComponent<AudioSource>().Stop();
    }



}
