using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesController : MonoBehaviour
{

    public GameObject[] SpikesArray;
    public PlayerControlls player;

    private int levelOfSpikes = 0;

    
    public void nextSpikes()
    {
             levelOfSpikes++;
        if (levelOfSpikes < SpikesArray.Length)
        {
            SpikesArray[levelOfSpikes].SetActive(true);  
        }
        if (levelOfSpikes == 6)
        {
            player.alive = false;
        }

    }
    
 } 