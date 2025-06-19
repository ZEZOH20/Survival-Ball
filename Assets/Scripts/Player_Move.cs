using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Rigidbody move_force;
    float force = 5.0f;
    GameObject follow_focal;
    public GameObject Indicator;
    public bool power = false;
    public float PlayingTime;
  
    // Start is called before the first frame update
    void Start()
    {
        move_force = GetComponent<Rigidbody>();
        follow_focal = GameObject.Find("Focal");

       
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        move_force.AddForce(follow_focal.transform.forward * force* vertical);
        Indicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        //score Time
        if (transform.position.y > -0.5f)
            PlayingTime += Time.deltaTime;
        
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("power"))
        {
            power = true;
            Indicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(4);
        power = false;
        Indicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
      
       if (collision.gameObject.CompareTag("Enemy") && power)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 enemyBounciness_Direction = collision.gameObject.transform.position - transform.position; 
            enemyRigidbody.AddForce(enemyBounciness_Direction * force, ForceMode.Impulse);
        }
    }
}
