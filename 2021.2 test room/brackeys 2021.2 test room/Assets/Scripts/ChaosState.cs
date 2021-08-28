using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosState : MonoBehaviour
{
    int currentHealth; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetCurrentHealth(int healthUpdate) 
    {
        currentHealth += healthUpdate; 

        
    }
}
