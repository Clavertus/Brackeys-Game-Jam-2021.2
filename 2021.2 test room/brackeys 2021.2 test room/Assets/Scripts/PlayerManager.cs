using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject c_Bullet;
    public GameObject cc_Bullet;

    public GameObject currentBullet;

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            currentBullet = c_Bullet;
        }

        if (Input.GetKeyDown("e"))
        {
            currentBullet = cc_Bullet;
        }
    }
}
