using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpBoost : MonoBehaviour
{
  
    CharacterController controller;
    GameObject player;
 
    Vector3 some;
 
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CharacterController>();
    }
 
    void OnTriggerStay()
    {
        some = new Vector3(player.transform.position.x, player.transform.position.y + 1200, player.transform.position.z);
        controller.Move(some * Time.deltaTime);
    }
}
