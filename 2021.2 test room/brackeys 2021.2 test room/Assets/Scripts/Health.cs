using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] Animator animator; 
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
        gameObject.GetComponent<ChaosState>().GetCurrentHealth(startingHealth);
        ChaosStateAnimator(); 

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DamageBox>()) 
        {
            TakeDamage();
        }
        else if(other.gameObject.GetComponent<HealingOrb>())
        {
            Heal(); 
        }
    }
    void TakeDamage()
    {
       
        /*
         var scaleDecrement = myScale -= myScale / startingHealth;
        outerChaosOrb.transform.localScale = 
            new Vector3(scaleDecrement.x, scaleDecrement.y, scaleDecrement.z);   
        */
        health--;
        boxSpawner.GetComponent<BoxSpawner>().HealthSum(-1);
        gameObject.GetComponent<ChaosState>().GetCurrentHealth(-1);

        ChaosStateAnimator(); 
        if (health <= 0) { Destroy(outerChaosOrb);  }
        FindObjectOfType<BoxSpawner>().UpdateBoxCount();
           
    }
    
    void Heal()
    {
        /*
        var scaleIncrement = myScale += myScale / startingHealth;
        outerChaosOrb.transform.localScale =
            new Vector3(scaleIncrement.x, scaleIncrement.y, scaleIncrement.z);
        */
        health++;
        ChaosStateAnimator();
        boxSpawner.GetComponent<BoxSpawner>().HealthSum(1);
        gameObject.GetComponent<ChaosState>().GetCurrentHealth(1);
        FindObjectOfType<BoxSpawner>().UpdateOrbCount();

    }

    void ChaosStateAnimator()
    {
        if(health >= startingHealth * .8) { animator.SetBool("HealthStage1", true); }
        else { animator.SetBool("HealthStage1", false); }

        if (health >= startingHealth * .6 && health < startingHealth * .8) { animator.SetBool("HealthStage2", true); } 
        else { animator.SetBool("HealthStage2", false); }

        if (health >= startingHealth * .4 && health < startingHealth * .6) { animator.SetBool("HealthStage3", true); }
        else { animator.SetBool("HealthStage3", false); }

        if (health >= startingHealth * .2 && health < startingHealth * .4) { animator.SetBool("HealthStage4", true); }
        else { animator.SetBool("HealthStage4", false); }

        if ( health < startingHealth * .2) { animator.SetBool("HealthStage5", true); }
        else { animator.SetBool("HealthStage5", false); }   
    }
}
