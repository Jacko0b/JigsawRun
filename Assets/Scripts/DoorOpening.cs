using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpening : MonoBehaviour
{
    public PlayerControlls player;
    public UI ui;
    public Animator animator;
    private void Awake()
    {
        player = GameObject.Find("PlayerController").GetComponent<PlayerControlls>();
        ui = GameObject.Find("UI").GetComponent<UI>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            openD();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        closeD();
        
    }
    public void openD()
    {

        if (player.goldKeys > 0)
        {
            showF(true);
            animator.SetBool("doorOpened", true);
            this.GetComponent<EdgeCollider2D>().isTrigger = true;

            if (player.pressedF == 1)
            {
                player.goldKeys--;
                if(SceneManager.GetActiveScene().buildIndex + 1==6) player.GameComplete();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                
            }
        }
    }

    public void closeD()
    {
        showF(false);
        animator.SetBool("doorOpened", false);
        this.GetComponent<EdgeCollider2D>().isTrigger = false;
    }
    public void showF(bool x)
    {
        if (x) ui.showF();
        else ui.hideF();
    }
}
