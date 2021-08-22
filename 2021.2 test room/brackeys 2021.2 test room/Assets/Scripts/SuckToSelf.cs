using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckToSelf : MonoBehaviour
{
    //config
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<GravitySwitcher>().EnteringOrb(gameObject);
    }

    
}
