using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundDamage : MonoBehaviour
{
    [SerializeField]private AudioSource audioSource;
    private PlayerHealth playerHealth;
    private PlayerSound playerSound;
    [SerializeField] private AudioClip damageSoundAudio;

    private void Start()
    {
        playerSound = GetComponent<PlayerSound>();
        playerHealth = GetComponent<PlayerHealth>();
        playerHealth.playerDamage += audioSoundDamage;
    }

    private void audioSoundDamage()
    {
        audioSource.time = 0.2f;
        audioSource.volume = 0.5f;
        audioSource.pitch = 0.5f;
        audioSource.clip = damageSoundAudio;
        audioSource.Play();
    }
}
