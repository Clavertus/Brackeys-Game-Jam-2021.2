using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamFollow : MonoBehaviour
{

    public GameObject player;

    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);    
    }
}
