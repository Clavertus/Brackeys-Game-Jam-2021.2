using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    string sourceString;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() && collision.gameObject.GetComponent<PlayerHealth>().health > Mathf.Epsilon)
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    sourceString = "Impaled on a metal spike";
                    break;

                case 1:
                    sourceString = "Got a flat tire on a spike";
                    break;

                case 2:
                    sourceString = "Hit the funny spot with a spike";
                    break;

                case 3:
                    sourceString = "Nailed it. Literally";
                    break;

                default:
                    sourceString = "Impaled on a metal spike";
                    break;
            }
        }


        if (collision.gameObject.GetComponent<PlayerHealth>()) 
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage, sourceString);
        }
    }
}
