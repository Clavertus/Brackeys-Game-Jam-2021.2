using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAim : MonoBehaviour
{
    public Transform sphereTransform;
    private Vector3 mouseScreenPosition;
    private Vector3 mouseWorldPosition;

    public Transform pointHint;


    void Update()
    {
        mouseScreenPosition = Input.mousePosition;

        mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x,
        mouseScreenPosition.y,
        Camera.main.nearClipPlane + 1)); 

        sphereTransform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, transform.position.z);

        if(mouseWorldPosition.x < transform.position.x)
        {
            pointHint.position = transform.position + new Vector3(2, 0, 0);
        } else
        {
            pointHint.position = transform.position + new Vector3(-2, 0, 0);
        }
    }
}
