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

    public int cg; //currentGrav from LevelManager.cs
    public GameObject levelManager;
    public float newPos;

    //state
    bool isGrounded; 
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("levelManager");
        myRigidBody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement(); 
        
        
    }

    private void Update()
    {
        cg = levelManager.GetComponent<LevelManager>().currentGrav;
        Jump();
    }

    private void Movement()
    {
        var delta = Input.GetAxisRaw("Horizontal") * playerMoveSpeed;
        
        switch (cg)
        {
            case 0:
                newPos = (transform.position.x + delta);
                transform.position = new Vector2(newPos, transform.position.y);

                break;

            case 1:
                newPos = (transform.position.y - delta);
                transform.position = new Vector2(transform.position.x, newPos);

                break;

            case 2:
                newPos = (transform.position.x + delta);
                transform.position = new Vector2(newPos, transform.position.y);

                break;

            case 3:
                newPos = (transform.position.y + delta);
                transform.position = new Vector2(transform.position.x, newPos);

                break;

        }
       
    }
    private void Jump()
    {
        
        isGrounded = feet.GetComponent<IsGrounded>().returnGroundedState();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)     
        {
            switch (cg)
            {
                case 0:
                    myRigidBody.AddForce(myRigidBody.velocity.x, jumpForce, myRigidBody.velocity.z);
                    break;

                case 1:
                    myRigidBody.AddForce(jumpForce, myRigidBody.velocity.y, myRigidBody.velocity.z);
                    break;

                case 2:
                    myRigidBody.AddForce(myRigidBody.velocity.x, -jumpForce, myRigidBody.velocity.z);
                    break;

                case 3:
                    myRigidBody.AddForce(-jumpForce, myRigidBody.velocity.y, myRigidBody.velocity.z);
                    break;

            }
          
        }
    }
}
