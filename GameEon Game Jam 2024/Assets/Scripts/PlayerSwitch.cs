using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSwitch : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public PlayerControllerScript player1Controller;
    public PlayerControllerScript player2Controller;

    public bool player1Active = true;

    private Transform followPlayer;

    public CinemachineVirtualCamera vCam;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            SwitchPlayer();
            FollowPlayer();
        }
    }

    public void SwitchPlayer()
    {
        if(player1Active)
        {
            // player1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            player1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            player1Controller.enabled = false;
            player1Controller.tag = "Player";

            // player2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            player2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            player2Controller.enabled = true;
            player2Controller.tag = "ActivePlayer";

            player1Active = false;
        }
        else
        {
            // player2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            player2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            player2Controller.enabled = false;
            player2Controller.tag = "Player";

            // player1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            player1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            player1Controller.enabled = true;
            player1Controller.tag = "ActivePlayer";

            player1Active = true;
        }
    }

    public void FollowPlayer()
    {
        followPlayer = GameObject.FindWithTag("ActivePlayer").transform;
        vCam.m_LookAt = followPlayer;
        vCam.m_Follow = followPlayer;
    }
}
