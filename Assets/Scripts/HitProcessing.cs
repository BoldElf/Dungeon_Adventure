using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitProcessing : MonoBehaviour
{
    [SerializeField] private RaycastPlayer raycastPlayer;

    public UnityAction DoorControllerInvoke;

    private void Start()
    {
        raycastPlayer.HitProcessingInvoke += InvokeHitProcessing;
    }

    private void InvokeHitProcessing(string tagObject)
    {
        if(tagObject == "Lever")
        {
            DoorControllerInvoke?.Invoke();
        }
    }
}
