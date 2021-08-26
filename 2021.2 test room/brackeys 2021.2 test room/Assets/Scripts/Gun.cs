using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject gunTip;
    [SerializeField] float bulletSpeed;
    Vector3 mouseWorldPosition;
    Vector3 aimDirection; 
    float angle;
    bool isDead = false; 


    private void Start()
    {
         
    }
    void Update()
    {
        if(isDead) { return; }
        Aiming();
        Shooting();
    }

    public void GunDeadState()
    {
        isDead = true; 
    }

    private void Aiming()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 1000f);

         aimDirection = (mouseWorldPosition - transform.position).normalized; 
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bulletInstance = Instantiate(bullet, gunTip.transform.position, Quaternion.identity);
            bulletInstance.GetComponent<Bullet>().BulletShot(aimDirection);    
        } 

    }



}
