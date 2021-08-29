using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public int currentGrav;

    // 0 for normal
    // 1 for left
    // 2 for up
    // 3 for right

    
    Vector3 currentEuler;

     float currentAngle;
     float desiredAngle;

    float rotTimer;
    public float rotTime;
    float perc;

    bool rotating;
    public bool u_rotating;

    public int[] time_s;
    public float[] sampleTimes;

    public float interval;
    public bool beatStarted;

    public AudioSource levelMusic;

    public int nSample;
    public int nextSample;

    public GameObject player;
    public GameObject volume;

    void Awake()
    {

        rotating = false;
        u_rotating = false;
        nSample = 1;
        nextSample = 1;

        interval = 7.68f;
        beatStarted = false;
        time_s = new int[500];
        sampleTimes = new float[500];




    }

    void Start()
    {

        for (int i = 0; i < sampleTimes.Length; i++)
        {
            sampleTimes[i] = interval * (i + 1);
        }

        for (int i = 0; i < time_s.Length; i++)
        {
            time_s[i] = Mathf.RoundToInt(sampleTimes[i] * levelMusic.clip.frequency);
        }



        StartCoroutine("NewUpdate");

    }



    IEnumerator NewUpdate()
    {
        if (levelMusic != null && !beatStarted)
        {
            levelMusic.Play();
            volume.GetComponent<Beat>().beatStarted = true;
            beatStarted = true;

        }

        if (beatStarted)
        {
            for (var k = 0; k < time_s.Length; k++)
            {
                nSample = time_s[k];
                nextSample = time_s[k + 1];
                while (levelMusic.timeSamples < nSample)
                {
                    yield return 0;
                }
                 if (currentGrav == 3)
                 {
                    currentGrav = 0;
                    rotating = true;
                    u_rotating = true;
                    player.GetComponent<PlayerManager>().PlaySound(player.GetComponent<PlayerManager>().gravityswitchSFX);

                  }
                 else
                    {
                    currentGrav++;
                    rotating = true;
                    u_rotating = true;
                    player.GetComponent<PlayerManager>().PlaySound(player.GetComponent<PlayerManager>().gravityswitchSFX);

                    }
            }
        }
        yield return new WaitForSeconds(Time.deltaTime);


        
       StartCoroutine("NewUpdate");
        


        






    }


    void Update()
    {


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
                u_rotating = false;
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
            player.transform.eulerAngles = currentEuler;
        }


    }


        






}
