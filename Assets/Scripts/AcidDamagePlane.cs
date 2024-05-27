using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AcidDamagePlane : MonoBehaviour
{
    private CameraMovment mainCamera;
    public UnityAction DownAcid;

    private void Start()
    {
        mainCamera = FindObjectOfType<CameraMovment>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            mainCamera.enabled = false;
            DownAcid?.Invoke();
        }
        
    }
}
