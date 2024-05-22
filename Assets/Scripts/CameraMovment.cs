using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    /*
    [SerializeField] private GameObject charector;

    [SerializeField] private float positionX;
    [SerializeField] private float positionY;
    [SerializeField] private float positionZ;

    [SerializeField] private float rotationX;
    [SerializeField] private float rotationY;
    [SerializeField] private float rotationZ;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = charector.transform.position;
        gameObject.transform.rotation = charector.transform.rotation;

        gameObject.transform.position = new Vector3(positionX, positionY, positionZ);
        gameObject.transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
    }

    private void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, charector.transform.position + new Vector3(positionX, positionY, positionZ), 1f);
        transform.Rotate(Vector3.forward, );
    }
    */

    [Header("Offset")]
    [SerializeField] private float viewHeight;
    [SerializeField] private float height;
    [SerializeField] private float distance;

    [Header("Damping")]
    [SerializeField] private float rotationDamping;
    [SerializeField] private float heightDamping;
    [SerializeField] private float speedThreshold;

    [SerializeField] private Transform target;
    [SerializeField] private new Rigidbody rigidbody;

    private void FixedUpdate()
    {
        Vector3 velocity = rigidbody.velocity;
        Vector3 targetRotation = target.eulerAngles; //Quaternion.LookRotation(velocity, Vector3.up).eulerAngles;

        /*
        if (velocity.magnitude > speedThreshold)
        {
            targetRotation = Quaternion.LookRotation(velocity, Vector3.up).eulerAngles;
        }
        */

        float currentAngle = Mathf.LerpAngle(transform.eulerAngles.y, targetRotation.y, rotationDamping * Time.fixedDeltaTime);
        float currentHeight = Mathf.Lerp(transform.position.y, target.position.y + height, heightDamping * Time.fixedDeltaTime);


        Vector3 positionOffset = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward * distance;
        transform.position = target.position - positionOffset;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        transform.LookAt(target.position + new Vector3(0, viewHeight, 0));
    }
}
