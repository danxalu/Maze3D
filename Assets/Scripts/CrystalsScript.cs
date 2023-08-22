using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalsScript : MonoBehaviour
{
    static public int crystals;
    static public int crystals_game;
    private float speedRotate = 50;

    private void Start()
    {
        crystals_game = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player_Game"))
        {
            CrystalSounds.On_Crystal = true;
            crystals_game++;
        }
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * speedRotate * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.right * speedRotate * Time.deltaTime, Space.Self);
    }


}
