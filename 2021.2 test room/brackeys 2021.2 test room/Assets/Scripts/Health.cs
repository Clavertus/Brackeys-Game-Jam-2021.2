using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int startingHealth = 10;
    int health; 
    [SerializeField] GameObject outerChaosOrb; 
    Vector3 myScale;
    private void Start()
    {
        health = startingHealth;
        myScale = outerChaosOrb.transform.localScale; 
    }

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage(); 
    }
    void TakeDamage()
    {
        var scaleDecrement = myScale -= myScale / startingHealth;
        outerChaosOrb.transform.localScale = 
            new Vector3(scaleDecrement.x, scaleDecrement.y, scaleDecrement.z);    
        health--;
        Debug.Log(health);  
        if (health <= 0) { Destroy(outerChaosOrb);  }
    }
    void Heal()
    {

    }
}
