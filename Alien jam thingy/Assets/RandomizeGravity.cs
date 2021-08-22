using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeGravity : MonoBehaviour
{

    public int currentGrav;

    public float gravForce;

    // 0 for normal
    // 1 for left
    // 2 for up
    // 3 for right

    public float currTimer;
    public float maxTimer;


    void Update()
    {
        currTimer += Time.deltaTime;
        if(currTimer >= maxTimer)
        {
            currTimer = 0;
            if (currentGrav == 3)
            {
                currentGrav = 0;
            } else
            {
                currentGrav++;
            }
            
        }
    }





}
