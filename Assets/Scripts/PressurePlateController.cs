using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public GameObject[] plate;
    public GameObject goldKey;
    public SpikesController spikesController;
    public int currentQueue = 0;
    public int[] queue = {2,0,11,1,6};
    public void FixedUpdate()
    {
        if (currentQueue == 6)
        {
            goldKey.SetActive(true);
        }
        for (int i = 0; i < plate.Length; i++ ) 
        {
            if (plate[i].GetComponent<PressurePlateOnTrigger>().pressed == true)
            {
                checkQueue(i);
            }
        }
    }
    public void checkQueue(int i)
    {
        if(plate[i].GetComponent<PressurePlateOnTrigger>().nr == queue[currentQueue]&& queue.Length<currentQueue) 
        {
            currentQueue++;
        }
        else
        {
            currentQueue = 0;
            spikesController.nextSpikes();
        }

    }

}
