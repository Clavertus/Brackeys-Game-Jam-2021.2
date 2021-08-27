using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject gravityBullet;
    public GameObject freezeBullet;

    public GameObject currentBullet;

    public GameObject capsule;

    public Material freezeMat;
    public Material gravMat;
    

    public string cb;

    void Start()
    {
        currentBullet = gravityBullet;
        cb = "gravity";
    }

    void Update()
    {


        if (Input.GetKeyDown("q") && cb == "gravity")
        {
            currentBullet = freezeBullet;
            cb = "freeze";
            capsule.GetComponent<MeshRenderer>().material = freezeMat;
        } else if (Input.GetKeyDown("q") && cb == "freeze")
            {
                currentBullet = gravityBullet;
                cb = "gravity";
            capsule.GetComponent<MeshRenderer>().material = gravMat;

        }






    }


}
