using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public Transform respawnPoint;

    private GameObject activePlayer;

    // public PlayerSwitch PlayerSwitch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // PlayerSwitch = GetComponent<PlayerSwitch>().CompareTag("ActivePlayer");
        activePlayer = GetComponent<PlayerSwitch>().gameObject.active;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("ActivePlayer"))
        {
            activePlayer.transform.position = respawnPoint.position;
        }
    }
}
