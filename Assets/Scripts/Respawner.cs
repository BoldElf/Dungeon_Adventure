using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    private PlayerMovmentV2_0 playerMovment;
    private PlayerHealth playerHealth;
    [SerializeField] private GameObject player;

    private bool startimer = false;
    private float timer = 0;

    private void Start()
    {
        playerMovment = player.GetComponent<PlayerMovmentV2_0>();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.playerDamage += respawnPlayer;
    }

    private void Update()
    {
        if(startimer == true)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 0.2f)
        {
            player.transform.position = gameObject.transform.position;
            timer = 0;
            startimer = false;
            Time.timeScale = 1;
            //audioSource.clip = null;
        }
    }

    private void respawnPlayer()
    {
        startimer = true;
    }
}
