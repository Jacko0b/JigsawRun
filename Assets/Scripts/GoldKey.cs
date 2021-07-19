using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldKey : MonoBehaviour
{

    public PlayerControlls player;
    public float rotatespeed = 20f;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find("PlayerController").GetComponent<PlayerControlls>();
    }
    private void FixedUpdate()
    {
        rotateKey();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            player.goldKeys++;
            this.gameObject.SetActive(false);
        }

    }
    private void rotateKey()
    {

        transform.Rotate(0, 0, rotatespeed * Time.deltaTime);
    }
}
