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

    float currTimer;
    public float maxTimer;
    Vector3 currentEuler;

     float currentAngle;
     float desiredAngle;

    float rotTimer;
    public float rotTime;
    float perc;

    bool rotating;

    public Transform player;

    void Awake()
    {
        rotating = false;
    }


    void Update()
    {


        currTimer += Time.deltaTime;
        if (currTimer >= maxTimer)
        {
            currTimer = 0;
            if (currentGrav == 3)
            {
                currentGrav = 0;
                rotating = true;
            }
            else
            {
                currentGrav++;
                rotating = true;
            }
        }

        if (rotating)
        {
            
             
            
            if(rotTimer < rotTime)
            {
                rotTimer += Time.deltaTime;
                perc = rotTimer / rotTime;
                perc = 1 - Mathf.Pow(2, -10 * perc);
            } else
            {
                rotTimer = 0;
                rotating = false;
            }


            switch (currentGrav)
            {
                case 0:
                     currentAngle = -270;
                     desiredAngle = -360;
                    break;

                case 1:
                    currentAngle = 0;
                    desiredAngle = -90;
                    break;

                case 2:
                    currentAngle = -90;
                    desiredAngle = -180;
                    break;

                case 3:
                    currentAngle = -180;
                    desiredAngle = -270;
                    break;

            }




            float newZ = Mathf.Lerp(currentAngle, desiredAngle, perc);
          
    
            currentEuler = new Vector3(0, 0, newZ);                 //that actually does the spinning
            player.eulerAngles = currentEuler;
        }


    }


        






}
