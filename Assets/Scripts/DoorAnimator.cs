using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    [SerializeField] private DoorController doorController;
    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        doorController.DoorControllerAnim += InvokeControllerDoor;
        doorController.DoorControllerAnimClose += CloseAnimControllerDoor;
    }

    private void InvokeControllerDoor()
    {
        animator.SetBool("Close", false);
        animator.SetBool("Open", true);
    }

    private void CloseAnimControllerDoor()
    {
        animator.SetBool("Open", false);
        animator.SetBool("Close", true);
    }
}
