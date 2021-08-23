using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject gunTip;
    [SerializeField] float bulletSpeed;
    Vector3 mouseWorldPosition; 
    float angle; 
    void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        angle = AngleBetweenPoints(transform.position, mouseWorldPosition);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        

    }

    
    float AngleBetweenPoints(Vector3 a, Vector3 b)
    {
        //some trigonometry bs. 
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;  
    }

    
    
}
