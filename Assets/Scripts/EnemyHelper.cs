using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyHelper : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Wall Left" || other.gameObject.name == "Wall Bot" || other.gameObject.CompareTag("Exit"))
                {
                if (name == "help_forward") EnemyVar.help_forward_do = false;
                else if (name == "help_right") EnemyVar.help_right_do = false;
                else if (name == "help_left") EnemyVar.help_left_do = false;
                else if (name == "help_back") EnemyVar.help_back_do = false;
                }
        EnemyVar.help_count++;
        //Debug.Log(EnemyVar.help_forward_do.ToString() + EnemyVar.help_back_do.ToString() + EnemyVar.help_left_do.ToString() + EnemyVar.help_right_do.ToString());
    }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.name == "Wall Left" || other.gameObject.name == "Wall Bot" || other.gameObject.CompareTag("Exit"))
                {
                if (name == "help_forward") EnemyVar.help_forward_do = true;
                else if (name == "help_right") EnemyVar.help_right_do = true;
                else if (name == "help_left") EnemyVar.help_left_do = true;
                else if (name == "help_back") EnemyVar.help_back_do = true;
                }
        EnemyVar.help_count++;
        //Debug.Log(EnemyVar.help_forward_do.ToString() + EnemyVar.help_back_do.ToString() + EnemyVar.help_left_do.ToString() + EnemyVar.help_right_do.ToString());
    }
    }