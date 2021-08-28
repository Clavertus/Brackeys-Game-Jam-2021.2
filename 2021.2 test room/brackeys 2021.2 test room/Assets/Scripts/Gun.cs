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

    public Transform playerCenter;

    public Vector3 lookAt;
    public Vector3 x_mouseScreenPosition;

    [SerializeField] Transform target;

    [SerializeField] float bulletSpeed;
    public Vector3 aimDirection; 
    float angle;
    public bool isDead = false; 


    private void Start()
    {
         
    }
    void Update()
    {
        if (!isDead)
        {
            bullet = player.GetComponent<PlayerManager>().currentBullet;

            x_mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            lookAt = x_mouseScreenPosition;

            float AngleRad = Mathf.Atan2(lookAt.y + aimDirection.y * 100 - this.transform.position.y, lookAt.x + aimDirection.x * 100 - this.transform.position.x);

            float AngleDeg = (180 / Mathf.PI) * AngleRad;

            capsule.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);


        }
        if (isDead) { return; }
        if (!isDead)
        {
            Aiming();
            Shooting();
        }
    }

    public void GunDeadState()
    {
        isDead = true; 
    }

    private void Aiming()
    {

        mouseScreenPosition = Input.mousePosition;

        mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x,
        mouseScreenPosition.y,
        Camera.main.nearClipPlane + 1));

        mouseInput = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, transform.position.z);



        aimDirection = (mouseInput - playerCenter.position).normalized; 

        


    }

    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bulletInstance = Instantiate(bullet, gunTip.transform.position, capsule.transform.rotation);
            bulletInstance.GetComponent<Bullet>().BulletShot(aimDirection);
            if (player.GetComponent<PlayerManager>().currentBullet == player.GetComponent<PlayerManager>().gravityBullet)
            {
                player.GetComponent<PlayerManager>().PlaySound(player.GetComponent<PlayerManager>().gravSFX);
            } else if(player.GetComponent<PlayerManager>().currentBullet == player.GetComponent<PlayerManager>().freezeBullet)
            {
                player.GetComponent<PlayerManager>().PlaySound(player.GetComponent<PlayerManager>().freezeSFX);

            }
        } 

    }



}
