using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatObject : MonoBehaviour
{
    public float speed = 15.0f;
    public float distance = 0.5f;
    public float spin = 1f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * speed, Time.deltaTime * speed), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * spin) * distance;

        transform.position = tempPos;
    }
}
