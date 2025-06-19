using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavEnemy : MonoBehaviour
{
    GameObject player;
    public float maxDistance;
    NavMeshAgent agent;
    float distance;
    public GameOverScreen GameOverScreen;
    void Start()
    {
        player = GameObject.Find("player");
        agent = GetComponent<NavMeshAgent>();

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = (player.transform.position - transform.position).magnitude;
        if(distance >= maxDistance)
        {
            agent.SetDestination(player.transform.position);
        }
        if(distance< agent.stoppingDistance)
        {
            //if touch end Game
           
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");

           
            GameOverScreen.Setup(
                player.GetComponent<Player_Move>().PlayingTime);
        }
    }
}
