using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LevelerSound : Sound
{
    /*
    [SerializeField] DoorController doorController;

    private AudioSource audioSource;

    private float timer = 0f;
    private bool timerStop;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        doorController.LevelerSoundAction += ActionLevelerSound;
    }


    private void Update()
    {
        if(timerStop == true)
        {
            timer += Time.deltaTime;

            if(timer >= 1f)
            {
                ActionLevelerSoundStop();
            }
        }
    }

    private void ActionLevelerSound()
    {
        audioSource.Play();
        timerStop = true;
    }

    private void ActionLevelerSoundStop()
    {
        timerStop = false;
        timer = 0;

        audioSource.Stop();
    }
    */
    

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        doorController.LevelerSoundAction += ActionLevelerSound;
    }
}
