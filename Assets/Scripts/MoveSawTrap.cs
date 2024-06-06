using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveSawTrap : MonoBehaviour
{
    [SerializeField] private GameObject saw;
    [SerializeField] private GameObject rightLocker;
    [SerializeField] private GameObject leftLocker;

    



    private bool goLeft = false;
    private bool goRight = true;



    //[Header("True direction - x or false direction - z")][SerializeField] private bool direction = true;
    [Header("DirectionX - object direction on x or turns || DirectionZ - object direction on z")]
    [SerializeField] private bool directionX = false;
    [SerializeField] private bool directionZ = false;

    [Header(" directionX = (0 or a right turn - positive || a left turn - negative) directionZ = (0 - negative || ) ")]
    [SerializeField] private bool rightLockerNegative = false;
    [SerializeField] private bool rightLockerPositive = false;

    // Update is called once per frame
    void Update()
    {
        directionMain();
    }

    private void directionMain()
    {
        if (directionX == true && directionZ == false || directionZ == true && directionX == false)
        {
            if (rightLockerNegative == true && rightLockerPositive == false || rightLockerPositive == true && rightLockerNegative == false)
            {
                if (rightLockerNegative == true)
                {
                    if (directionX == true)
                    {
                        directionOnXNegative();
                    }
                    else
                    {
                        directionOnZNegative();
                    }
                }
                if (rightLockerPositive == true)
                {
                    if (directionX == true)
                    {
                        directionOnXPositiv();
                    }
                    else
                    {
                        directionOnZPositive();
                    }
                }
            }
            else
            {
                Debug.Log("NonRightLockerState");
            }

        }
        else
        {
            Debug.Log("NonDirection");
        }
    }

    private void directionOnXNegative()
    {
        if (goLeft == false && goRight == true)
        {
            if (saw.transform.position.x < rightLocker.transform.position.x)
            {
                //saw.transform.position += new Vector3(Time.deltaTime, 0,0);
                saw.transform.position = Vector3.MoveTowards(saw.transform.position, rightLocker.transform.position, Time.deltaTime);
            }
            else
            {
                goLeft = true;
                goRight = false;
            }
        }

        if (goRight == false && goLeft == true)
        {
            if (saw.transform.position.x > leftLocker.transform.position.x)
            {
                //saw.transform.position += new Vector3(-Time.deltaTime, 0,0);
                saw.transform.position = Vector3.MoveTowards(saw.transform.position, leftLocker.transform.position, Time.deltaTime);
            }
            else
            {
                goLeft = false;
                goRight = true;
            }
        }
    }

    private void directionOnXPositiv()
    {
        if (goLeft == false && goRight == true)
        {
            if (saw.transform.position.x > rightLocker.transform.position.x)
            {
                //saw.transform.position += new Vector3(Time.deltaTime, 0,0);
                saw.transform.position = Vector3.MoveTowards(saw.transform.position, rightLocker.transform.position, Time.deltaTime);
            }
            else
            {
                goLeft = true;
                goRight = false;
            }
        }

        if (goRight == false && goLeft == true)
        {
            if (saw.transform.position.x < leftLocker.transform.position.x)
            {
                //saw.transform.position += new Vector3(-Time.deltaTime, 0,0);
                saw.transform.position = Vector3.MoveTowards(saw.transform.position, leftLocker.transform.position, Time.deltaTime);
            }
            else
            {
                goLeft = false;
                goRight = true;
            }
        }
    }

    private void directionOnZNegative()
    {
        if (goLeft == false && goRight == true)
        {
            if (saw.transform.position.z > leftLocker.transform.position.z)
            {
                saw.transform.position += new Vector3(0, 0, -Time.deltaTime);
            }
            else
            {
                goLeft = true;
                goRight = false;
            }
        }

        if (goLeft == true && goRight == false)
        {
            if (saw.transform.position.z < rightLocker.transform.position.z)
            {
                saw.transform.position += new Vector3(0, 0, Time.deltaTime);
            }
            else
            {
                goLeft = false;
                goRight = true;
            }
        }
    }

    private void directionOnZPositive()
    {
        if (goLeft == false && goRight == true)
        {
            if (saw.transform.position.z < leftLocker.transform.position.z)
            {
                saw.transform.position += new Vector3(0, 0, Time.deltaTime);
            }
            else
            {
                goLeft = true;
                goRight = false;
            }
        }

        if (goLeft == true && goRight == false)
        {
            if (saw.transform.position.z > rightLocker.transform.position.z - 0.1f)
            {
                saw.transform.position += new Vector3(0, 0, -Time.deltaTime);
            }
            else
            {
                goLeft = false;
                goRight = true;
            }
        }
    }


}
