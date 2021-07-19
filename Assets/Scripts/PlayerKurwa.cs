using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKurwa : MonoBehaviour
{

    public PlayerControlls player;

    private void Awake()
    {
        player = GameObject.Find("PlayerController").GetComponent<PlayerControlls>();

    }
    private void FixedUpdate()
    {
    }
    public void setAnimation(Vector2 v2, int jumpPerformed)
    {

        GetComponent<Animator>().SetInteger("jump", (int)player.jumpPerformed);
        GetComponent<Animator>().SetInteger("x", (int) player.v2.x);
        GetComponent<Animator>().SetInteger("y", (int) player.v2.y);

    }
}
