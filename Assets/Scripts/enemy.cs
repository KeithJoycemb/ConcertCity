using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject spherePrefab;
    public float sphereSpeed = 10f;
    public float sphereLifetime = 2f;
    public float shootCooldown = 1f;
    public Transform characterTransform;
    public AudioClip hitSound;

    private float lastShootTime;

    void Start()
    {
        lastShootTime = Time.time;
    }

    void Update()
    {
        // Check if enough time has passed since the last shoot
        if (Time.time - lastShootTime >= shootCooldown)
        {
            // Calculate the direction from the sphere shooter to the character
            Vector3 directionToCharacter = characterTransform.position - transform.position;

            // Create a new sphere and shoot it towards the character
            GameObject sphere = Instantiate(spherePrefab, transform.position, Quaternion.identity);
            Rigidbody sphereRigidbody = sphere.GetComponent<Rigidbody>();
            sphereRigidbody.velocity = directionToCharacter.normalized * sphereSpeed;
            Destroy(sphere, sphereLifetime);

            // Update the last shoot time
            lastShootTime = Time.time;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "character")
        {
            // Play hit sound
            AudioSource.PlayClipAtPoint(hitSound, transform.position);

            // Destroy sphere
            Destroy(gameObject);
        }
    }
}