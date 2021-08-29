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
                    sourceString = "Electro condensated by a neon light";
                    break;

                case 1:
                    sourceString = "Systems crashed, UPS reccomended";
                    break;

                case 2:
                    sourceString = "Hit the funny spot with a neon light";
                    break;

                case 3:
                    sourceString = "Nailed it. Literally";
                    break;

                default:
                    sourceString = "System crashed, UPS reccomended";
                    break;
            }
        }


        if (collision.gameObject.GetComponent<PlayerHealth>()) 
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage, sourceString);
        }

        if (gameObject.CompareTag("Singularity Bullet")) { Debug.Log("destroy"); Destroy(gameObject); } 

    }
}
