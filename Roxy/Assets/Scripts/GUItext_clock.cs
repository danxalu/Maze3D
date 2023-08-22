using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUItext_clock : MonoBehaviour
{
    private float secundomer;
    private float time;
    private float min;
    private float sec;

    private void Start()
    {
        secundomer = 0f;
        time = 0f;
    }
    private void Update()
    {
        secundomer += Time.deltaTime;
        if (secundomer >= 1)
        {
            time += 1f;
            secundomer = 0f;
        }
        if (time < 60) GetComponent<Text>().text = time.ToString()+"s";
        else
        {
            sec = time % 60;
            min = (time - sec) / 60;
            GetComponent<Text>().text = min.ToString() + "m " + sec.ToString() + "s";
        }
    }
}

