using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 1f;
    [SerializeField] HealthBar healthBar;
    [SerializeField] float health; 

    private void Start()
    {
        health = maxHealth; 
        healthBar.SetMaxHealth(maxHealth); 
    }

    public void TakeDamage(float damage)
    {
        health -= damage; 
        healthBar.SetHealth(health);  
        
    }
}
