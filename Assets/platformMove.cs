using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{
    public float speed = 2.0f;
    public float distance = 5.0f;

    private float initialY;
    private bool movingUp = true;

    void Start()
    {
        initialY = transform.position.y;
    }

    void Update()
    {
        float newY = transform.position.y;
        if (movingUp)
        {
            newY += speed * Time.deltaTime;
            if (newY >= initialY + distance)
            {
                movingUp = false;
            }
        }
        else
        {
            newY -= speed * Time.deltaTime;
            if (newY <= initialY)
            {
                movingUp = true;
            }
        }
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
