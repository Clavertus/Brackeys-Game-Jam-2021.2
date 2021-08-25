using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    Material mat;
    Quaternion fixedRotation;

    void Awake()
    {
        fixedRotation = transform.rotation;
    }



    
}
