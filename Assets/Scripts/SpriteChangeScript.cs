using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChangeScript : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        sr.sprite = Resources.Load<Sprite>("Spikes"); 

       // print("zwolniono");
        //door.closeDoor();
    }
}
