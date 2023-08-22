using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControls : MonoBehaviour
{
    private Transform Camera;

    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        float dist = Vector3.Distance(Camera.position, transform.position);
        if (dist <= 13.5f)
            GetComponent<Renderer>().material.renderQueue = 2500;
        else
            GetComponent<Renderer>().material.renderQueue = 5000;
    }
}
