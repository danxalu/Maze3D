using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Get_wi : MonoBehaviour
{
    static public float timer_get_wi;
    [SerializeField] private GameObject Get_WI;

    private void OnEnable()
    {
        Get_WI.SetActive(false);
    }

    private void Update()
    {
        if (timer_get_wi >= 3) Get_WI.SetActive(true);
        else
        {
            Get_WI.SetActive(false);
            timer_get_wi += Time.deltaTime;
        }

     }
}
