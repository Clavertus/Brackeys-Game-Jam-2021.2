using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FuelBar : MonoBehaviour
{
    public Image fuelBar;
    public GameObject player;
    public float fuel;

    void Update()
    {

        gameObject.GetComponent<RectTransform>().localScale =
            new Vector3(
            player.GetComponent<PlayerHealth>().fuel / player.GetComponent<PlayerHealth>().maxFuel,
            gameObject.GetComponent<RectTransform>().localScale.y,
            gameObject.GetComponent<RectTransform>().localScale.z
            );

        if (player.GetComponent<PlayerHealth>().fuel <= 0)
        {
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(
                0,
                gameObject.GetComponent<RectTransform>().localScale.y,
                gameObject.GetComponent<RectTransform>().localScale.z);
        }


    }


}
