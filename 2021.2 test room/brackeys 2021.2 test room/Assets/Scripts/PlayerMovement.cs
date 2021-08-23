using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //config
    [SerializeField] float playerMoveSpeed = 1f;
    [SerializeField] float jumpForce = .2f;
    [SerializeField] GameObject feet; 
    Rigidbody myRigidBody; 

    //state
    bool isGrounded; 
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement(); 
        
        
    }

    private void Update()
    {
        Jump();
    }

    private void Movement()
    {
        var deltaX = Input.GetAxisRaw("Horizontal") * playerMoveSpeed;
        var newXPos = (transform.position.x + deltaX);
        transform.position = new Vector2(newXPos, transform.position.y);  
    }
    private void Jump()
    {
        
        isGrounded = feet.GetComponent<IsGrounded>().returnGroundedState();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)     
        {
            myRigidBody.AddForce(myRigidBody.velocity.x, jumpForce, myRigidBody.velocity.z); 
        }
    }
}
