using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public Transform respawnPoint;

    private GameObject activePlayer;

    private PlayerSwitch playerSwitch;

    private void Start()
    {
        playerSwitch = GetComponent<PlayerSwitch>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        activePlayer = playerSwitch.activePlayer.gameObject;
        Debug.Log(activePlayer);

        activePlayer.transform.position = respawnPoint.transform.position;
    }
}
