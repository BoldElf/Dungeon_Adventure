using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    private void Update()
    {
        transform.localPosition += new Vector3(0, 0, -Time.deltaTime * 5);
    }
}
