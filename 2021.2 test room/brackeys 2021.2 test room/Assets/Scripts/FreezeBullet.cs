using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBullet : MonoBehaviour
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
        if (bulletWasShot) { BulletVelocity(); }
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
        if (other.gameObject.GetComponent<GravityController>() && other.gameObject.name != "Player")
        {

            other.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            other.gameObject.tag = ("Frozen");
            other.gameObject.transform.GetChild(0).GetChild(1).tag = ("Frozen");
            other.gameObject.transform.GetChild(0).GetChild(1).GetComponent<BoxArrow>().hit = true;


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
