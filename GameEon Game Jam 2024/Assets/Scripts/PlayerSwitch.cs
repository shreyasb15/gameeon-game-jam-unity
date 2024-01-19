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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            SwitchPlayer();
        }
    }

    public void SwitchPlayer()
    {
        if(player1Active)
        {
            player1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            player1Controller.enabled = false;

            player2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            player2Controller.enabled = true;

            player1Active = false;
        }
        else
        {
            player2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            player1Controller.enabled = true;

            player1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            player2Controller.enabled = false;

            player1Active = true;
        }
    }
}
