using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    public Material baseShader;
    public Material fadeShader;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player has entered the trigger");

        if (other.gameObject.layer == 3)
        {
            GetComponent<Renderer>().material = fadeShader;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Player has exited the trigger");

        if (other.gameObject.layer == 3)
        {
            GetComponent<Renderer>().material = baseShader;
        }
    }
}
