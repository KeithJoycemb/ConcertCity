using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkController : MonoBehaviour
{
    public GameObject blinkEffectPrefab; // the prefab for the blink effect
    public float blinkDistance = 5f; // the distance the character will blink
    public float blinkDuration = 0.2f; // the duration of the blink effect
    public LayerMask blinkLayerMask; // the layer mask for the blink raycast

    private CharacterController characterController; // reference to the character controller component

    void Start()
    {
        characterController = GetComponent<CharacterController>(); // get the character controller component on start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // change the input key to "e" for blinking
        {
            Vector3 blinkDirection = Camera.main.transform.forward; // get the camera's forward direction
            Vector3 blinkStartPosition = transform.position; // start the blink from the character's position

            RaycastHit hit; // store information about what the blink raycast hits

            if (Physics.Raycast(blinkStartPosition, blinkDirection, out hit, blinkDistance, blinkLayerMask))
            {
                blinkStartPosition = hit.point; // if the blink hits something, start the blink from the point of impact
            }
            else
            {
                blinkStartPosition += blinkDirection * blinkDistance; // if the blink doesn't hit anything, start the blink at the maximum distance
            }

            GameObject blinkEffect = Instantiate(blinkEffectPrefab, blinkStartPosition, Quaternion.identity); // instantiate the blink effect prefab
            Destroy(blinkEffect, blinkDuration); // destroy the blink effect after the specified duration

            characterController.enabled = false; // temporarily disable the character controller component
            transform.position = blinkStartPosition; // move the character to the new position
            characterController.enabled = true; // re-enable the character controller component
        }
    }
}






