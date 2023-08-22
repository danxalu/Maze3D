using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DontDestroy_3 : MonoBehaviour
{
    public static bool created = false;
    void Awake()
    {
        if (created) Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(transform.root.gameObject);
            created = true;
        }
    }
}