using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRollerMove : MonoBehaviour
{
    public PlayerControlls player;
    public Vector3 v3= new Vector3(1,0.5f,0);
    public float rollingSpeed = 2.5f;
    public bool comingback = false;
    public int timeToStart = 3;
    private void Awake()
    {
        player = GameObject.Find("PlayerController").GetComponent<PlayerControlls>();
    }
    private void FixedUpdate()
    {

        if (transform.position.x < 28 || transform.position.y < 14)
        {
            if (comingback == false)
            {
                
                if (Time.timeSinceLevelLoad > timeToStart)
                    transform.Translate(v3 * rollingSpeed * Time.deltaTime);
            }

        }
        else comingback = true;
        if (comingback == true)
        {
            transform.Translate(-v3 * rollingSpeed * Time.deltaTime);
        }
        if (transform.position.x<-2)
        {
            comingback = !comingback;
        }
           
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            player.alive = false;
        }
    }
}
