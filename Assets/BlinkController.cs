using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkController : MonoBehaviour
{
    public GameObject blinkEffectPrefab; // the prefab for the blink effect
    public float blinkDistance = 5f; // the distance the character will blink
    public float blinkDuration = 0.2f; // the duration of the blink effect
    public LayerMask blinkLayerMask; // the layer mask for the blink raycast
    private bool isBlinking = false;
    private float blinkReset;
    private AudioSource audioSource;
    private AudioSource audioSource2;
    public AudioClip blinkSucess;
    public AudioClip blinkFail;

    private CharacterController characterController; // reference to the character controller component

    void Start()
    {
        characterController = GetComponent<CharacterController>(); // get the character controller component on start
        blinkReset = blinkDistance;
        audioSource = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isBlinking) // add a check for whether the character is currently blinking
        {
            StartCoroutine(BlinkCoroutine()); // start the coroutine for the blink
        }

    }

    IEnumerator BlinkCoroutine()
    {
        isBlinking = true; // set the isBlinking flag to true

        Vector3 blinkDirection = Camera.main.transform.forward; // get the camera's forward direction
        Vector3 blinkStartPosition = transform.position; // start the blink from the character's position

        RaycastHit hit; // store information about what the blink raycast hits

        if (Physics.Raycast(blinkStartPosition, blinkDirection, out hit, blinkDistance, blinkLayerMask))
        {
            blinkDistance = 0; // if the blink hits something, start the blink from the point of impact

            audioSource2.PlayOneShot(blinkFail);
        }
        else
        {
            blinkStartPosition += blinkDirection * blinkDistance; // if the blink doesn't hit anything, start the blink at the maximum distance
            audioSource.PlayOneShot(blinkSucess);
        }

        GameObject blinkEffect = Instantiate(blinkEffectPrefab, blinkStartPosition, Quaternion.identity); // instantiate the blink effect prefab

        characterController.enabled = false; // temporarily disable the character controller component
        transform.position = blinkStartPosition; // move the character to the new position
        characterController.enabled = true;
        yield return new WaitForSeconds(blinkDuration); // wait for the blink duration
        Destroy(blinkEffect); // destroy the blink effect
        isBlinking = false; // set the isBlinking flag to false
        blinkDistance = blinkReset;
    }
}






