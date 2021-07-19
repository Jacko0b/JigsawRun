using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public PlayerControlls player;
    private void Awake()
    {
        player = GameObject.Find("PlayerController").GetComponent<PlayerControlls>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!player.isInAir && collision.CompareTag("Player")==true)
        {
            player.alive = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!player.isInAir && collision.CompareTag("Player") == true)
        {
            player.alive = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!player.isInAir && collision.CompareTag("Player") == true)
        {
            player.alive = false;
        }
    }
}
