using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DownTrap : MonoBehaviour
{
    public UnityAction trapStart;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            trapStart?.Invoke();
        }
    }

}
