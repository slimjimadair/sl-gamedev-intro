using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public Transform sphereTransform;

    void Start()
    {
        sphereTransform.parent = transform;
        sphereTransform.localScale = Vector3.one * 2;
    }


    void Update()
    {
        transform.Rotate(Vector3.up * 180 * Time.deltaTime, Space.World);
        transform.Translate(Vector3.forward * 7 * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sphereTransform.localPosition = Vector3.zero;
        }
    }
}
