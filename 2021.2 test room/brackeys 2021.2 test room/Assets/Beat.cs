using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Beat : MonoBehaviour
{
    float currTimer;
    public float interval;

    public bool beatStarted;

    private Volume v;
    public Animator anim;
    private Vignette vg;

    public AudioSource levelMusic;

    public int[] time_s;
    public float[] sampleTimes;


    // Start is called before the first frame update
    
    void Awake()
    {

        interval = 0.48f;
        beatStarted = false;
        time_s = new int[500];
        sampleTimes = new float[500];
    }

    void Start()
    {
        for(int i = 0; i < sampleTimes.Length; i++)
        {
            sampleTimes[i] = interval * (i + 1);
        }

        for (int i = 0; i < time_s.Length; i++)
        {
            time_s[i] = Mathf.RoundToInt(sampleTimes[i] * levelMusic.clip.frequency);
        }

        v = GetComponent<Volume>();
        v.profile.TryGet(out vg);
        StartCoroutine("Pulse");
    }


    void Update()
    {
        if (beatStarted)
        {
            for (var k = 1; k < time_s.Length; k++)
            {              
                var nSample = time_s[k] * levelMusic.clip.frequency;
                while (levelMusic.timeSamples < nSample)
                {
                    continue;
                }
                vg.intensity.value = 0.5f;
            }
        }    
    }

    public IEnumerator Pulse()
    {

        yield return new WaitForSeconds(0f);
        vg.intensity.value -= Time.deltaTime;
        StartCoroutine("Pulse");
        
       
        
    }

   
}
