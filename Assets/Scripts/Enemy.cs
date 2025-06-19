using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    Rigidbody enemy_force;
    public float force;
  
    // Start is called before the first frame update
    void Start()
    {
        enemy_force = GetComponent<Rigidbody>();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        enemy_force.AddForce((player.transform.position - transform.position).normalized * force, ForceMode.Force);

    }
}
