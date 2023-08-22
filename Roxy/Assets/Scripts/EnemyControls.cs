using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;


public class EnemyVar
{
    [SerializeField] public static float Speed;

    public static GameObject help_forward;
    public static GameObject help_back;
    public static GameObject help_right;
    public static GameObject help_left;

    public static bool help_forward_do;
    public static bool help_back_do;
    public static bool help_right_do;
    public static bool help_left_do;
    public static int help_count;

    public static string help_lastest;
    public static string help_lastest_do;

    public static bool move_enemy;

    public static int RandomDirection;

    public static Rigidbody componentRigidbody;

    public static int furthestX;
    public static int furthestY;

    public static GameObject EnemyHelper;

    public static float timer;
    public static float timer_help;
}
public class EnemyControls : MonoBehaviour
{

    private void Start()
    {
        EnemyVar.move_enemy = false;
        EnemyVar.timer = 100;
        EnemyVar.Speed = 5;
        EnemyVar.EnemyHelper = GameObject.FindGameObjectWithTag("EnemyHelper");
        EnemyVar.componentRigidbody = GetComponent<Rigidbody>();
        EnemyVar.help_forward = Instantiate(EnemyVar.EnemyHelper, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z + 5), Quaternion.identity);
        EnemyVar.help_forward.name = "help_forward";
        EnemyVar.help_right = Instantiate(EnemyVar.EnemyHelper, new Vector3(transform.position.x + 5, transform.position.y + 10, transform.position.z), Quaternion.identity);
        EnemyVar.help_right.name = "help_right";
        EnemyVar.help_left = Instantiate(EnemyVar.EnemyHelper, new Vector3(transform.position.x - 5, transform.position.y + 10, transform.position.z), Quaternion.identity);
        EnemyVar.help_left.name = "help_left";
        EnemyVar.help_back = Instantiate(EnemyVar.EnemyHelper, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z - 5), Quaternion.identity);
        EnemyVar.help_back.name = "help_back";
        EnemyVar.help_forward_do = true;
        EnemyVar.help_right_do = true;
        EnemyVar.help_left_do = true;
        EnemyVar.help_back_do = true;
        //transform.position = new Vector3((MazeGenerator.Width - 2) * 10 + 5, 2.5f, (MazeGenerator.Height - 2) * 10 + 5);
    }

    private void RandomDirection()
    {
        EnemyVar.RandomDirection = UnityEngine.Random.Range(1, 5);
        if (EnemyVar.timer == -1) EnemyVar.move_enemy = true;
    }

    private void Go(GameObject other)
    {
        EnemyVar.move_enemy = false;
        if (EnemyVar.timer == 100) EnemyVar.timer = 0;
        EnemyVar.help_count = 0;
        Vector3 Floor = other.transform.position;
        EnemyVar.help_forward.transform.position = new Vector3(Floor.x, Floor.y + 10, Floor.z + 5);
        EnemyVar.help_right.transform.position = new Vector3(Floor.x + 5, Floor.y + 10, Floor.z);
        EnemyVar.help_left.transform.position = new Vector3(Floor.x - 5, Floor.y + 10, Floor.z);
        EnemyVar.help_back.transform.position = new Vector3(Floor.x, Floor.y + 10, Floor.z - 5);
        transform.SetPositionAndRotation(new Vector3(other.transform.position.x, 2.5f, other.transform.position.z), Quaternion.identity);
        RandomDirection();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Floor")
        {
            Go(other.gameObject);
        }

        if (other.gameObject.CompareTag("Player_Game"))
        {
            EnemyVar.move_enemy = false;
            EnemyVar.RandomDirection = 0;
            EnemyVar.help_lastest = "";
            EnemyVar.help_lastest_do = "";
            EnemyVar.help_forward_do = true;
            EnemyVar.help_right_do = true;
            EnemyVar.help_left_do = true;
            EnemyVar.help_back_do = true;
            EnemyVar.timer = 100;

            CrystalsScript.crystals_game = (int)Math.Floor((double)(CrystalsScript.crystals_game / 2));
            other.transform.SetPositionAndRotation(new Vector3(15, 3, 15), Quaternion.identity);
        }
    }

    public void Update()
    {
        if (EnemyVar.timer >= 1.5 && EnemyVar.timer != 100)
        {
            transform.SetPositionAndRotation(new Vector3(EnemyVar.furthestX * 10 + 5, 2.5f, EnemyVar.furthestY * 10 + 5), Quaternion.identity);
            EnemyVar.move_enemy = true;
            EnemyVar.timer = -1;

        }
        else if(EnemyVar.timer != -1 && EnemyVar.timer != 100)
        {
            EnemyVar.timer += Time.deltaTime;
        }
        else if(EnemyVar.timer == 100)
        {
            transform.SetPositionAndRotation(new Vector3(EnemyVar.furthestX * 10 + 5, 2.5f, EnemyVar.furthestY * 10 + 5), Quaternion.identity);
            //EnemyVar.move_enemy = true;
            //EnemyVar.timer = -1;
        }

        if (EnemyVar.help_count < 3 && EnemyVar.timer_help < 1000) EnemyVar.timer_help = 1000;

        if(EnemyVar.timer_help >= 1000)
        {
            if (EnemyVar.timer_help < 1000.5) EnemyVar.timer_help += Time.deltaTime;
            else
            {
                EnemyVar.help_count = 3;
                EnemyVar.timer_help = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        if (EnemyVar.move_enemy && EnemyVar.help_count >= 3) 
    {
        //ВПЕРЕД
        if (EnemyVar.RandomDirection == 1)
        {
            if (EnemyVar.help_forward_do)
            {
            if (EnemyVar.help_lastest == "help_forward_do")
            {
                if (!(EnemyVar.help_right_do || EnemyVar.help_left_do || EnemyVar.help_back_do))
                {
                    EnemyVar.componentRigidbody.MovePosition(transform.position + new Vector3(0, 0, 5) * Time.fixedDeltaTime * EnemyVar.Speed);
                    EnemyVar.help_lastest = "help_back_do";
                } else RandomDirection();
            }
            else
            {
                EnemyVar.componentRigidbody.MovePosition(transform.position + new Vector3(0, 0, 5) * Time.fixedDeltaTime * EnemyVar.Speed);
                EnemyVar.help_lastest = "help_back_do";
            }
            } else RandomDirection();
        } 


        //ВПРАВО
            if (EnemyVar.RandomDirection == 2)
            {
            if(EnemyVar.help_right_do)
            {
                if (EnemyVar.help_lastest == "help_right_do")
                {
                    if (!(EnemyVar.help_forward_do || EnemyVar.help_left_do || EnemyVar.help_back_do))
                    {
                        EnemyVar.componentRigidbody.MovePosition(transform.position + new Vector3(5, 0, 0) * Time.fixedDeltaTime * EnemyVar.Speed);
                        EnemyVar.help_lastest = "help_left_do";
                        } else RandomDirection();
            }
                else
                {
                    EnemyVar.componentRigidbody.MovePosition(transform.position + new Vector3(5, 0, 0) * Time.fixedDeltaTime * EnemyVar.Speed);
                    EnemyVar.help_lastest = "help_left_do";
                    }
                } else RandomDirection();
            }


        //ВЛЕВО
            if (EnemyVar.RandomDirection == 3)
            {
            if (EnemyVar.help_left_do)
            {
                if (EnemyVar.help_lastest == "help_left_do")
                {
                    if (!(EnemyVar.help_forward_do || EnemyVar.help_right_do || EnemyVar.help_back_do))
                    {
                        EnemyVar.componentRigidbody.MovePosition(transform.position + new Vector3(-5, 0, 0) * Time.fixedDeltaTime * EnemyVar.Speed);
                        EnemyVar.help_lastest = "help_right_do";

                        }
                    else RandomDirection();
                }
                else
                {
                    EnemyVar.componentRigidbody.MovePosition(transform.position + new Vector3(-5, 0, 0) * Time.fixedDeltaTime * EnemyVar.Speed);
                    EnemyVar.help_lastest = "help_right_do";
                    }
                } else RandomDirection();
            }


        //НАЗАД
        if (EnemyVar.RandomDirection == 4)
        {
        if (EnemyVar.help_back_do)
        {
                if (EnemyVar.help_lastest == "help_back_do")
                {
                    if (!(EnemyVar.help_forward_do || EnemyVar.help_right_do || EnemyVar.help_left_do))
                    {
                        EnemyVar.componentRigidbody.MovePosition(transform.position + new Vector3(0, 0, -5) * Time.fixedDeltaTime * EnemyVar.Speed);
                        EnemyVar.help_lastest = "help_forward_do";
                        }
                    else RandomDirection();
                }
                else
                {
                    EnemyVar.componentRigidbody.MovePosition(transform.position + new Vector3(0, 0, -5) * Time.fixedDeltaTime * EnemyVar.Speed);
                    EnemyVar.help_lastest = "help_forward_do";
                    }
                } else RandomDirection();
        }
    }
    }
}

 