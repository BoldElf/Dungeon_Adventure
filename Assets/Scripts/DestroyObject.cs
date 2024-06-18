using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    //[SerializeField] private float timerToDeath;
    //private float timer;

    private void Update()
    {
        /*
        timer += Time.deltaTime;

        if(timer >= timerToDeath)
        {
            Destroy(gameObject);
        }    
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("a");
        if(collision.gameObject.tag == "Wall")
        {
            Debug.Log("a");
            Destroy(gameObject);
        } 
    }
    */
}
