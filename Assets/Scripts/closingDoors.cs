using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closingDoors : MonoBehaviour
{
    public Animator animator;
    private void Awake()
    {
        animator.SetBool("doorOpened", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        closeD();
    }

    public void closeD()
    {
        animator.SetBool("doorOpened", false);
        GetComponent<EdgeCollider2D>().isTrigger = false;
    }

}
