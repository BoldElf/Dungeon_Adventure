using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(PlayerMovmentV2_0))]

public class PlayerSound : MonoBehaviour
{
    PlayerMovmentV2_0 playerMovment;
    AudioSource audioSource;

    private float timer;
    private float timerDown;

    private bool timerDownStart = false;

    private bool itsWalk = false;

    //private bool DownSoundWas = false;

    private bool timerUpStart = false;
    private float timerUpCounter;

    private Rigidbody rb_object;
    [SerializeField] private AudioClip WalkSoundAudio;
    [SerializeField] private AudioClip JumpSoundAudio;
    [SerializeField] private AudioClip DownSoundAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb_object = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        playerMovment = GetComponent<PlayerMovmentV2_0>();
        playerMovment.playerWalk += playerWalkSound;
        playerMovment.playerJump += playerJumpControllerSound;
        playerMovment.playerDown += playerDownSound;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        
        if(timerDownStart == true)
        {
            timerDown += Time.deltaTime;
        }    

        if(timerDown >= 0.2f)
        {
            audioSource.Stop();
            audioSource.clip = null;
            timerDownStart = false;
            timerDown = 0f;
            //DownSoundWas = false;
        }

        if(timerUpStart == true)
        {
            timerUpCounter += Time.deltaTime;

            if(timerUpCounter >= 0.3f)
            {
                playerJumpSoundWait();
            }
        }
    }

    private void playerWalkSound()
    {
        if (timer >= 0.4f && rb_object.velocity.y == 0)
        {
            if (audioSource.isActiveAndEnabled == false) return;
            if (audioSource.isPlaying)
            {
                timer = 0;
                return;
            }

            audioSource.volume = 0.432f;
            audioSource.pitch = 1.01f;

            audioSource.clip = WalkSoundAudio;
            audioSource.Play();
            itsWalk = true;
            timer = 0;
        }
        else
        {
            //itsWalk = false;
            return;
        }
    }
    private void playerJumpControllerSound()
    {
        if(itsWalk == true)
        {
            playerJumpSound();
            itsWalk = false;
            return;
        }

        if (audioSource.isPlaying)
        {
            timerUpStart = true;
            return;
        }

        playerJumpSound();
    } 

    private void playerJumpSound()
    {
        audioSource.volume = 0.5f;
        audioSource.pitch = 0.5f;
        audioSource.clip = JumpSoundAudio;
        audioSource.Play();
    }

    private void playerJumpSoundWait()
    {
        audioSource.Stop();
        audioSource.volume = 0.5f;
        audioSource.pitch = 0.5f;
        audioSource.clip = JumpSoundAudio;
        timerUpStart = false;
        timerUpCounter = 0f;
        audioSource.Play();
    }

    private void playerDownSound()
    {
        audioSource.volume = 0.5f;
        audioSource.pitch = 0.5f;
        audioSource.clip = DownSoundAudio;
        audioSource.Play();
        //DownSoundWas = true;

        timerDownStart = true;
    }
}
