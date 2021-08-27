using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [SerializeField] public float health;

    [SerializeField] public float maxFuel;
    [SerializeField] public float fuel;


    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject gun;
    public Text cause;

    public Animator anim;


    private void Start()
    {
        maxFuel = 20;
        maxHealth = 100;
        fuel = maxFuel;
        health = maxHealth; 
    }
    
    public void TakeDamage(float damage, string source)
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
            anim.Play("TextFallDown");
            cause.text = source;
        }
    }


    public void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && fuel > 0)
        {
            gameObject.GetComponent<PlayerMovement>().playerMoveSpeed = 0.1f;
            fuel -= Time.deltaTime;
        } else
        {
            gameObject.GetComponent<PlayerMovement>().playerMoveSpeed = 0.04f;
        }
    }
    
}