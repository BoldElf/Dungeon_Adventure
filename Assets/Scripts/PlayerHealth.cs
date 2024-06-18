using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    private PlayerMovmentV2_0 playerMovment;

    private int health = 3;

    public UnityAction playerDamage;
    public UnityAction respawnPlayer;

    private void Start()
    {
        playerMovment = GetComponent<PlayerMovmentV2_0>();
    }

    public void MinusHealthPlayer()
    {
        if(health > 0)
        {
            Debug.Log(health);
            health -= 1;
            Time.timeScale = 0;
            playerDamage?.Invoke();
            respawnPlayer?.Invoke();
        }
    }
}
