using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public bool isGrounded;

    public int jumpsRemaining;
    public int maxJumpsRemaining;

    public void Start()
    {
        maxJumpsRemaining = 1;
        jumpsRemaining = 1;
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
