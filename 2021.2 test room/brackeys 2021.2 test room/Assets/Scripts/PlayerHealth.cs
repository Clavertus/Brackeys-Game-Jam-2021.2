using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public  float maxHealth = 1f;
    [SerializeField] public float health;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject gun; 


    private void Start()
    {
        

        health = maxHealth; 
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;

        if(damage >= health)
        {
            health = 0;
        }

        if (health <= Mathf.Epsilon)
        {
            GetComponent<PlayerMovement>().DeadState();
            gun.GetComponent<Gun>().GunDeadState();

            gameOver.SetActive(true);
        }
    }
    
}
