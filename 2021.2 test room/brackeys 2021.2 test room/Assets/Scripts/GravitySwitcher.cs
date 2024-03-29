using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToOrb : MonoBehaviour 
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
    Vector3 orbPos;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingToOrb) { MoveTowards();  return; } 
        if (enteredOrbArea) { Rotate(); }
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



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("center chaos")) { Destroy(gameObject);  }  
    }
}
