using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 1f;
    [SerializeField] HealthBar healthBar;
    [SerializeField] float health;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject gun; 


    private void Start()
    {
        gameOverCanvas.GetComponent<Canvas>().enabled = false; 

        health = maxHealth; 
        healthBar.SetMaxHealth(maxHealth); 
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage; 
        healthBar.SetHealth(health);
        if (health <= Mathf.Epsilon)
        {
            GetComponent<PlayerMovement>().DeadState();
            gun.GetComponent<Gun>().GunDeadState();  

            gameOverCanvas.GetComponent<Canvas>().enabled = true;   
        }
    }
    
}
