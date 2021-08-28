using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Image health;
    public GameObject player;

    void Update()
    {

        health.fillAmount = player.GetComponent<PlayerHealth>().health / player.GetComponent<PlayerHealth>().maxHealth;

        if (player.GetComponent<PlayerHealth>().health <= 0)
        {
            health.fillAmount = 0;
        }

         
    }


}
