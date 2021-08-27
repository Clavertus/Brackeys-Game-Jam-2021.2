using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject gunTip;
    [SerializeField] GameObject capsule;
    [SerializeField] GameObject player;

    public Vector3 mouseScreenPosition;
    public Vector3 mouseWorldPosition;
    public Vector3 mouseInput;

    [SerializeField] Transform target;

    [SerializeField] float bulletSpeed;
    Vector3 aimDirection; 
    float angle;
    bool isDead = false; 


    private void Start()
    {
         
    }
    void Update()
    {
        bullet = player.GetComponent<PlayerManager>().currentBullet;
        capsule.transform.LookAt(target);


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

        mouseScreenPosition = Input.mousePosition;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x,
        mouseScreenPosition.y,
        Camera.main.nearClipPlane + 1));

        mouseInput = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, transform.position.z);



        aimDirection = (mouseInput - transform.position).normalized; 

        


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
