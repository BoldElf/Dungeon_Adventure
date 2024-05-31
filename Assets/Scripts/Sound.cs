using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] protected DoorController doorController;

    protected AudioSource audioSource;

    private float timer = 0f;
    private bool timerStop;

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

    protected virtual void ActionLevelerSound()
    {
        audioSource.Play();
        timerStop = true;
    }

    protected virtual void ActionLevelerSoundStop()
    {
        timerStop = false;
        timer = 0;

        audioSource.Stop();
    }
}
