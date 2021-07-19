using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressurePlateOnTrigger : MonoBehaviour
{
    public PlayerControlls player;
    public Animator animator;
    public bool pressed = false;
    public int nr=0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!player.isInAir && collision.CompareTag("Player") == true)
        {
            animator.SetBool("pressed", true);
            pressed = true;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!player.isInAir && collision.CompareTag("Player") == true)
        {
            pressed = false;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!player.isInAir && collision.CompareTag("Player") == true)
        {
            animator.SetBool("pressed", false);
        }
        
    }
}
