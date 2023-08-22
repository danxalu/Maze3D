using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;
    private UnityEngine.Vector3 offset;

    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player_Game").transform;
        offset = transform.position - lookAt.position;
    }

    void Update()
    {
        transform.position = lookAt.position + offset;
    }
}