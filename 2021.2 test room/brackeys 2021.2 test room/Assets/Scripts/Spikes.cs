using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] float damage = .2f; 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>()) 
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Debug.Log("test");
        }
    }
}
