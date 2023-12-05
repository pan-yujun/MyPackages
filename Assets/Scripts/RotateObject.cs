using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private Vector3 rotate = Vector3.up;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotate, Time.deltaTime * speed);
    }
}
