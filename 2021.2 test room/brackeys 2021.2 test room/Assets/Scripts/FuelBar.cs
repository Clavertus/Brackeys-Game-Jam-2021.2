using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FuelBar : MonoBehaviour
{
    public Image fuelBar;
    public GameObject player;

    void Update()
    {

        fuelBar.fillAmount = player.GetComponent<PlayerHealth>().fuel / player.GetComponent<PlayerHealth>().maxFuel;

        if (player.GetComponent<PlayerHealth>().health <= 0)
        {
            fuelBar.fillAmount = 0;
        }


    }


}
