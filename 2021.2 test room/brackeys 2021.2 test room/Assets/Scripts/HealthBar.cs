using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Image health;
    public GameObject player;
    public float hp;

    void Update()
    {

        gameObject.GetComponent<RectTransform>().localScale = 
            new Vector3(
            player.GetComponent<PlayerHealth>().health / player.GetComponent<PlayerHealth>().maxHealth,
            gameObject.GetComponent<RectTransform>().localScale.y, 
            gameObject.GetComponent<RectTransform>().localScale.z
            );

        if(player.GetComponent<PlayerHealth>().health <= 0)
        {
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(
                0,
                gameObject.GetComponent<RectTransform>().localScale.y,
                gameObject.GetComponent<RectTransform>().localScale.z);
        }

         
    }


}
