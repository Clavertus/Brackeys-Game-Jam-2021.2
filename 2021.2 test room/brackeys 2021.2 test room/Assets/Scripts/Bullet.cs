using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody myRigidBody;
    [SerializeField] float bulletSpeed = 5f;
    Vector3 shootAngle;
    bool bulletWasShot = false; 
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        if(bulletWasShot) {  BulletVelocity();  } 
    }
    public void BulletShot(Vector3 aimDirection)
    {
        
        shootAngle = aimDirection;
        bulletWasShot = true; 
    }

    void BulletVelocity()
    {       
        myRigidBody.velocity = shootAngle * bulletSpeed;  
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GravityController>() && !other.gameObject.CompareTag("c")) 
        {
            other.gameObject.tag = ("c"); 
        }
        else if (other.gameObject.GetComponent<GravityController>() && other.gameObject.CompareTag("c"))
        {
            other.gameObject.tag = ("cc"); 
        }
    } 
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GravityController>() && gameObject.name == "cBullet(Clone)")
        {
            other.gameObject.tag = ("c");
        }
        else if (other.gameObject.GetComponent<GravityController>() && gameObject.name == "ccBullet(Clone)")
        {
            other.gameObject.tag = ("cc");
        }
    }
    */


}
