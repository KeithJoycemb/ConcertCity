using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;
    public AudioClip pickupSound;
    private MeshRenderer meshRenderer;
    private new Collider collider;
    private new Light light;

    private AudioSource audioSource;

    void Awake() => total++;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
        light = GetComponent<Light>();
    }
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        // This checks if its the player who collided with it then disables aeverything attacked to the object except the audio, and once its done playing it destroys the object
        if(other.CompareTag("Player"))
        {
            

            OnCollected?.Invoke();
            audioSource.PlayOneShot(pickupSound);
            meshRenderer.enabled = false;
            collider.enabled = false;
            light.enabled = false;
            StartCoroutine(DestroyAfterSound());
        }
    }

    IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(pickupSound.length);
        Destroy(gameObject);
    }
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
