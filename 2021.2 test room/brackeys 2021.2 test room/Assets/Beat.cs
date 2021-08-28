using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Beat : MonoBehaviour
{
    float currTimer;
    public float barTime;

    private Volume v;
    public Animator anim;
    private Vignette vg;
    // Start is called before the first frame update
    void Start()
    {
        v = GetComponent<Volume>();
        v.profile.TryGet(out vg);
        StartCoroutine("Pulse");
    }


    void Update()
    {
        if(currTimer < barTime)
        {
            currTimer += Time.deltaTime;
        } else
        {
            currTimer = 0;
            vg.intensity.value = 0.350f;
        }
    }

    public IEnumerator Pulse()
    {

        yield return new WaitForSeconds(0f);
        vg.intensity.value -= Time.deltaTime;
        StartCoroutine("Pulse");
        
       
        
    }

   
}
