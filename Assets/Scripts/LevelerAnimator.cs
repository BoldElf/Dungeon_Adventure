using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LevelerAnimator : MonoBehaviour
{
    [SerializeField] private DoorController doorController;
    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        doorController.LevelerControllerAnim += InvokeControllerLeveler;
        doorController.LevelerControllerAnimClose += CloseAnimControllerLeveler;
    }

    private void InvokeControllerLeveler()
    {
        animator.SetBool("Close", false);
        animator.SetBool("Open", true);
    }

    private void CloseAnimControllerLeveler()
    {
        animator.SetBool("Open", false);
        animator.SetBool("Close", true);
    }
}
