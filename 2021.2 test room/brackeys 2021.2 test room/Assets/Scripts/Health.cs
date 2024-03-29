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
    public ParticleSystem damageVFX;
    public ParticleSystem destroyVFX;
    public ParticleSystem healVFX;
    GameObject winConditions; 

    [SerializeField] BoxSpawner boxSpawner;
    int chaosState = 0; 
    private void Start()
    {
        health = startingHealth;
        myScale = outerChaosOrb.transform.localScale;
        boxSpawner.GetComponent<BoxSpawner>().HealthSum(startingHealth);

        winConditions = FindObjectOfType<WinConditions>().gameObject; 
        winConditions.GetComponent<WinConditions>().UpdateSumHealth(startingHealth);  
        winConditions.GetComponent<WinConditions>().initialHealthUpdate(); 

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
        
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().PlaySound(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().singularityDamagedSFX);

        boxSpawner.GetComponent<BoxSpawner>().HealthSum(-1);
        winConditions.GetComponent<WinConditions>().UpdateSumHealth(-1);
        if(damageVFX == null) { return;  }
        damageVFX.Play();


        ChaosStateAnimator(); 
        if (health <= 0) {
            Destroy(outerChaosOrb, 1f);
            destroyVFX.Play();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().PlaySound(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().singularityDestroyedSFX);
        }
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
        healVFX.Play();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().PlaySound(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().healSFX);

        ChaosStateAnimator();
        boxSpawner.GetComponent<BoxSpawner>().HealthSum(1);
        winConditions.GetComponent<WinConditions>().UpdateSumHealth(1); 
        FindObjectOfType<BoxSpawner>().UpdateOrbCount();

    }

    void ChaosStateAnimator()
    {
        if(health >= startingHealth * .8) { animator.SetBool("HealthStage1", true); chaosState = 0; }
        else { animator.SetBool("HealthStage1", false); }

        if (health >= startingHealth * .6 && health < startingHealth * .8) { animator.SetBool("HealthStage2", true); chaosState = 0; } 
        else { animator.SetBool("HealthStage2", false); }

        if (health >= startingHealth * .4 && health < startingHealth * .6) { animator.SetBool("HealthStage3", true); chaosState = 1; }
        else { animator.SetBool("HealthStage3", false); }

        if (health >= startingHealth * .2 && health < startingHealth * .4) { animator.SetBool("HealthStage4", true); chaosState = 2; }
        else { animator.SetBool("HealthStage4", false); }

        if ( health < startingHealth * .2) { animator.SetBool("HealthStage5", true); chaosState = 3; }
        else { animator.SetBool("HealthStage5", false); }

        GetChaosState();
    }
    public void GetChaosState() { gameObject.GetComponent<ChaosState>().UpdateChaosState(chaosState); }   
}
