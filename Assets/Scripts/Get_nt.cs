using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Get_nt : MonoBehaviour
{
    static public float timer_get_nt;
    [SerializeField] private GameObject Get_NT;

    private void OnEnable()
    {
        timer_get_nt = 0;
        Get_NT.SetActive(false);
    }

    private void Update()
    {
        if (timer_get_nt >= 3) Get_NT.SetActive(true);
        else
        {
            Get_NT.SetActive(false);
            timer_get_nt += Time.deltaTime;
        }

    }
}
