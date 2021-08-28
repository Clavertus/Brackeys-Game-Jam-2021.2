using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //config
    [SerializeField] public float playerMoveSpeed = 0.15f;
    [SerializeField] float jumpForce;
    [SerializeField] GameObject feet;

     
    
    Rigidbody myRigidBody;

    public int cg; //currentGrav from LevelManager.cs
    public GameObject levelManager;
    public float newPos;

    //state
    bool isGrounded;
    bool isDead = false; 
 
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("levelManager");
        myRigidBody = GetComponent<Rigidbody>();
        Time.fixedDeltaTime = 0.005f;
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

    public void DeadState()
    {
        isDead = true; 
    }
    private void Movement()
    {
        if (isDead) { return;  }
        var delta = Input.GetAxisRaw("Horizontal") * playerMoveSpeed;
        
        switch (cg)
        {
            case 0:
                newPos = (transform.position.x + delta);
                transform.position = new Vector3(newPos, transform.position.y, transform.position.z);

                break;

            case 1:
                newPos = (transform.position.y - delta);
                transform.position = new Vector3(transform.position.x, newPos, transform.position.z);

                break;

            case 2:
                newPos = (transform.position.x + delta);
                transform.position = new Vector3(newPos, transform.position.y, transform.position.z);

                break;

            case 3:
                newPos = (transform.position.y + delta);
                transform.position = new Vector3(transform.position.x, newPos, transform.position.z);

                break;

        }
       
    }
    private void Jump()
    {
        if (isDead) { return;  }

        isGrounded = feet.GetComponent<IsGrounded>().returnGroundedState();
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || feet.GetComponent<IsGrounded>().jumpsRemaining > 0))     
        {
            switch (cg)
            {
                case 0:
                    myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, 0, myRigidBody.velocity.z);
                    myRigidBody.AddForce(myRigidBody.velocity.x, jumpForce, myRigidBody.velocity.z);
                    break;

                case 1:
                    myRigidBody.velocity = new Vector3(0, myRigidBody.velocity.y, myRigidBody.velocity.z);
                    myRigidBody.AddForce(jumpForce, myRigidBody.velocity.y, myRigidBody.velocity.z);
                    break;

                case 2:
                    myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, 0, myRigidBody.velocity.z);
                    myRigidBody.AddForce(myRigidBody.velocity.x, -jumpForce, myRigidBody.velocity.z);
                    break;

                case 3:
                    myRigidBody.velocity = new Vector3(0, myRigidBody.velocity.y, myRigidBody.velocity.z);
                    myRigidBody.AddForce(-jumpForce, myRigidBody.velocity.y, myRigidBody.velocity.z);
                    break;

            }

            feet.GetComponent<IsGrounded>().jumpsRemaining--;



        }
        
    }


}
