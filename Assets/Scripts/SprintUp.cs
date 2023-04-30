using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintUp : MonoBehaviour
{
    private StarterAssets.ThirdPersonController sprint;
    private MeshRenderer meshToHide;
    public AudioClip powerupSound;
    float powerUpDuration = 0f;


    private AudioSource audioSource1;
    void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
        sprint = GameObject.Find("MainCharacter").GetComponent<StarterAssets.ThirdPersonController>();
        meshToHide = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioSource1.PlayOneShot(powerupSound);
            sprint.SprintSpeed = 10.0f;
            meshToHide.enabled = false;
            powerUpDuration += 3f;
        }
    }

  

    void Update()
    {
        if (powerUpDuration > 0)
        {
            powerUpDuration -= Time.deltaTime;
            if (powerUpDuration < 0)
            {
                sprint.SprintSpeed = 5f;
                Destroy(this.gameObject);
            }
        }
    }
}
