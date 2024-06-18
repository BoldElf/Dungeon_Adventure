using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutWheelDamage : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        playerHealth.playerDamage();
    }
}
