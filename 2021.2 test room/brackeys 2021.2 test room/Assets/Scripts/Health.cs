using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int startingHealth = 10;
    int health; 
    [SerializeField] GameObject outerChaosOrb;
    Vector3 myScale;

    [SerializeField] BoxSpawner boxSpawner; 
    private void Start()
    {
        health = startingHealth;
        myScale = outerChaosOrb.transform.localScale;
        boxSpawner.GetComponent<BoxSpawner>().HealthSum(startingHealth);

    }

    private void OnTriggerEnter(Collider other)
    {
        //will make this check more specific to the boxes when we add more scripts to them. 
        if (other.gameObject.GetComponent<GravityController>())
        {
            TakeDamage();
        }
    }
    void TakeDamage()
    {
        var scaleDecrement = myScale -= myScale / startingHealth;
        outerChaosOrb.transform.localScale = 
            new Vector3(scaleDecrement.x, scaleDecrement.y, scaleDecrement.z);    
        health--;
        boxSpawner.GetComponent<BoxSpawner>().HealthSum(-1);

        if (health <= 0) { Destroy(outerChaosOrb);  }
    }
    
    void Heal()
    {

    }
}
