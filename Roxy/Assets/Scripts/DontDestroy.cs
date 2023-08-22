﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
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
