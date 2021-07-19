using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeBox : MonoBehaviour
{
    public PlayerControlls player;
    public UI ui;
    public Animator animator;

    public bool showPrompt = true;
    public bool chestUsed = false;
    private void Awake()
    {
        player = GameObject.Find("PlayerController").GetComponent<PlayerControlls>();
        ui = GameObject.Find("UI").GetComponent<UI>();
    }

    private void FixedUpdate()
    {
        if (chestUsed)
            animator.SetBool("openBox", true);
        else
            animator.SetBool("openBox", false);


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            openChest();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        showF(false);
    }
    public void openChest()
    {
        if (player.pressedF == 1 && player.silverKeys > 0 && !chestUsed)
        {
            player.alive = false;
            showPrompt = false;
            chestUsed = true;
            showF(false);
        }
        else if (!chestUsed)
        {
            showF(true);
        }
    }
    public void showF(bool x)
    {
        if (x) ui.showF();
        else ui.hideF();
    }
}
