using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_rotate : MonoBehaviour
{
    float horizontal;
    public float rotate_speed;
    public GameObject player;

    public GameOverScreen GameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * rotate_speed * horizontal);

        if (player.transform.position.y < -0.5f)
        {
            //Game Over
            GameOverScreen.Setup(
               player.GetComponent<Player_Move>().PlayingTime);
        }
    }
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        /*horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * rotate_speed * horizontal);*/
    }
}
