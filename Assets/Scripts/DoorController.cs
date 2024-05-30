using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorController : MonoBehaviour
{
    [SerializeField] HitProcessing hitProcessing;

    public UnityAction DoorControllerAnim;
    public UnityAction LevelerControllerAnim; 
    
    public UnityAction DoorControllerAnimClose;
    public UnityAction LevelerControllerAnimClose;

    private bool timerStart = false;
    private float timerToCloseDoor;
    [SerializeField] private float maxTimeToCloseDoor;

    private void Start()
    {
        hitProcessing.DoorControllerInvoke += InvokeControllerDoor;
    }

    private void Update()
    {
        if(timerStart == true)
        {
            timerToCloseDoor += Time.deltaTime;
        }

        if(timerToCloseDoor >= maxTimeToCloseDoor)
        {
            CloseControllerDoor();
        }
    }

    private void InvokeControllerDoor()
    {
        DoorControllerAnim?.Invoke();
        LevelerControllerAnim?.Invoke();
        timerStart = true;
    }

    private void CloseControllerDoor()
    {
        timerStart = false;
        timerToCloseDoor = 0;

        DoorControllerAnimClose?.Invoke();
        LevelerControllerAnimClose?.Invoke();
    }
}
