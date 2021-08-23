using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public int currentGrav;

    // 0 for normal
    // 1 for left
    // 2 for up
    // 3 for right

    public float currTimer;
    public float maxTimer;

    public GameObject player;


    void Update()
    {
        currTimer += Time.deltaTime;
        if (currTimer >= maxTimer)
        {
            currTimer = 0;
            if (currentGrav == 3)
            {
                currentGrav = 0;
                player.transform.Rotate(0, 0, -90);
            }
            else
            {
                currentGrav++;
                player.transform.Rotate(0, 0, -90);
            }

        }
    }





}
