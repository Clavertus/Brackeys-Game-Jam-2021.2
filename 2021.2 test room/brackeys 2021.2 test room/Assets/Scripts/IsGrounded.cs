using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    bool isGrounded;

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;  
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
