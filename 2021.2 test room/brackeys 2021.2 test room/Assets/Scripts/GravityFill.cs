using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityFill : MonoBehaviour
{
    public Image timer;
    int nSample;
    int nextSample;
    int timeS;
    
    public GameObject levelManager;

     int sampleSize;
     int sampleDelta;
    
    void Start()
    {
         nSample = levelManager.GetComponent<LevelManager>().nSample;
        nextSample = levelManager.GetComponent<LevelManager>().nextSample;
        sampleSize = nextSample - nSample;

    }

    void Update()
    {
        
        sampleDelta = nSample - levelManager.GetComponent<LevelManager>().levelMusic.timeSamples;
        
        nSample = levelManager.GetComponent<LevelManager>().nSample;
        nextSample = levelManager.GetComponent<LevelManager>().nextSample;
        sampleSize = nextSample - nSample;


        timer.fillAmount = (float)sampleDelta / sampleSize;


        
    }

   
    
}
