using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public Transform respawnPoint;

    private GameObject activePlayer;

    private PlayerSwitch playerSwitch;

    private GameObject player1;
    private GameObject player2;

    private void Start()
    {
        playerSwitch = GetComponent<PlayerSwitch>();
        player1 = GetComponent<PlayerSwitch>().player1;
        player2 = GetComponent<PlayerSwitch>().player2;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player1 || other.gameObject == player2)
        {
            activePlayer = playerSwitch.activePlayer.gameObject;
            Debug.Log(activePlayer);

            activePlayer.transform.position = respawnPoint.transform.position;
        }
    }
}
