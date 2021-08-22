using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitcher : MonoBehaviour
{
    //state
    bool gravityRight = false;
    bool gravityLeft = false;
    bool gravityUp = false;
    bool gravityDown = false;
    bool zeroGravity = false;
    bool isMovingToOrb = false;
    bool enteredOrbArea = false; 

    //config
    Rigidbody myRigidbody;
    [SerializeField] Vector3 rightGravity;

    [Header("Portal Config")]
    [SerializeField] float portalSuckSpeed = .2f;
    [SerializeField] float rotateTime = 1f;
    [SerializeField] float rotateSpeed = .1f;
    [SerializeField] float rotateSpeedIncrement = .1f;
    Vector3 orbPos;
    void Start()
    {
        gravityRight = true; 
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingToOrb) { MoveTowards();  return; }
        if (enteredOrbArea) { Rotate(); }
        if (gravityRight){ SetGravityRight(); }
    }
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

    void MoveTowards()
    {   
          transform.position = Vector3.MoveTowards 
                     (transform.position, orbPos, portalSuckSpeed); 
    }

    void Rotate()
    { 
        rotateSpeed -= rotateSpeedIncrement;
        transform.Rotate(rotateSpeed, rotateSpeed, rotateSpeed * -rotateSpeed, Space.World);   
    }



    private void SetGravityRight()
    {
        myRigidbody.AddForce(rightGravity, ForceMode.Acceleration);
  
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("center chaos")) { Destroy(gameObject);  }  
    }
}
