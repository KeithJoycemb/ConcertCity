using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuCamera : MonoBehaviour
{
    public Transform targetObject;
    public float cameraDistance = 10.0f;
    public float cameraHeight = 5.0f;
    public float cameraSpeed = 2.0f;
    public float maxRotation = 10.0f;

    private float currentAngle = 0.0f;
    private bool rotateRight = true;

    void Start()
    {
        transform.position = targetObject.position - cameraDistance * Vector3.forward + cameraHeight * Vector3.up;
        transform.LookAt(targetObject);
    }

    void Update()
    {
        if (rotateRight)
        {
            currentAngle += cameraSpeed * Time.deltaTime;
            if (currentAngle >= maxRotation)
            {
                rotateRight = false;
            }
        }
        else
        {
            currentAngle -= cameraSpeed * Time.deltaTime;
            if (currentAngle <= -maxRotation)
            {
                rotateRight = true;
            }
        }

        transform.position = targetObject.position - cameraDistance * (Quaternion.Euler(0, currentAngle, 0) * Vector3.forward) + cameraHeight * Vector3.up;
        transform.LookAt(targetObject);
    }
}
