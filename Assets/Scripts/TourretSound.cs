using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourretSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private SpawnerArrow spawnerArrow;

    private void Start()
    {
        spawnerArrow = gameObject.GetComponent<SpawnerArrow>();
        spawnerArrow.arrowStartSound += StartSound;
    }

    private void StartSound()
    {
        audioSource.Play();
    }
}
