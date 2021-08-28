using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public bool isGrounded;

    public int jumpsRemaining;
    public int maxJumpsRemaining;
    public GameObject player;

    public void Start()
    {
        maxJumpsRemaining = 1;
        jumpsRemaining = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "floor" && !isGrounded)
        {
            player.GetComponent<PlayerManager>().PlaySound(player.GetComponent<PlayerManager>().landingSFX);
        } else if (other.tag == "Inverted" || other.tag == "Untagged" || other.tag == "Frozen" )
        {
            player.GetComponent<PlayerManager>().PlaySound(player.GetComponent<PlayerManager>().landing2SFX);
        }
            
    }

    private void OnTriggerStay(Collider other)
    {
            
            isGrounded = true;
            jumpsRemaining = maxJumpsRemaining;
      
    }
    private void OnTriggerExit(Collider other)
    {
        isGrounded = false; 
    }
    public bool returnGroundedState()
    {
        return isGrounded; 
    }
}
