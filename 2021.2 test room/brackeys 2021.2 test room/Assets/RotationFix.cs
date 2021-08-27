using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFix : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<SuckToSelf>() != null)
        {
            transform.GetChild(0).GetChild(1).GetComponent<BoxArrow>().alive = false;
        }
    }
}
