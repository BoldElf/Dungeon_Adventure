using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorSound : Sound
{
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        doorController.LevelerSoundAction += ActionLevelerSound;
    }
}
