using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitcher : MonoBehaviour
{
    //state
    bool isMovingToOrb = false;
    bool enteredOrbArea = false; 

    //config
    Rigidbody myRigidbody;

    [Header("Portal Config")]
    [SerializeField] float portalSuckSpeed = .2f;
    [SerializeField] float rotateTime = 1f;
    [SerializeField] float rotateSpeed = .1f;
    [SerializeField] float rotateSpeedIncrement = .1f;

    public float xddddddddd;

    Vector3 orbPos;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.useGravity = false;

    }

    
    private void FixedUpdate()
    {
        if (isMovingToOrb) { MoveTowards(); return; }
        if (enteredOrbArea) { Rotate(); }  
    }
    //called in SuckToSelf.cs, feeds in the singularity that called it.
    public void EnteringOrb(GameObject orb)
    {
       StartCoroutine(MoveTowardsOrb(orb));

    }

    private IEnumerator MoveTowardsOrb(GameObject orb)
    {
        myRigidbody.isKinematic = enabled;
        orbPos = orb.transform.position; 
        enteredOrbArea = true;  
        yield return new WaitForSeconds(rotateTime); 
        isMovingToOrb = true;
    }


    //called in update when isMovingToOrb is true.
    void MoveTowards()
    {


        transform.position = Vector3.MoveTowards 
                     (transform.position, orbPos, portalSuckSpeed);  
    } 

    //called in update when enteredOrbArea is true. 
    void Rotate()
    {
        rotateSpeed -= rotateSpeedIncrement;
        transform.Rotate(rotateSpeed, rotateSpeed, rotateSpeed * -rotateSpeed, Space.World);

    }



    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("center chaos"))     
        {
             

            Destroy(gameObject);  
        }   
    }
}
