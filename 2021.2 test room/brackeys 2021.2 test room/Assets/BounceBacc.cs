using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBacc : MonoBehaviour
{

    [SerializeField] float damage = 40f;
    string sourceString;



    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
            Debug.Log(rb.gameObject.name);
            Debug.Log("Force received: " + rb.velocity + "   Force applied: " + -rb.velocity.normalized * 3);

            rb.AddForce(-rb.velocity.normalized * 0.7f, ForceMode.Impulse);
        }

        if (collision.gameObject.GetComponent<PlayerHealth>() && collision.gameObject.GetComponent<PlayerHealth>().health > Mathf.Epsilon)
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    sourceString = "Annihilated by otherwordly creatures";
                    break;

                case 1:
                    sourceString = "Bounced back by funny purple ball";
                    break;

                case 2:
                    sourceString = "You weren't supposed to touch that.";
                    break;

                case 3:
                    sourceString = "Boink!";
                    break;

                default:
                    sourceString = "Annihilated by otherwordly creatures";
                    break;
            }
        }


        if (collision.gameObject.GetComponent<PlayerHealth>())
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage, sourceString);
        }

    }
}
