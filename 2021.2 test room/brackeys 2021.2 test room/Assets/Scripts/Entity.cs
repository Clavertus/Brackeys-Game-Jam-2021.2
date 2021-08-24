using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    Material mat;

    void Awake()
    {
        mat = gameObject.GetComponent<MeshRenderer>().material;
    }
    void Update()
    {
        switch (tag)
        {
            case "Untagged":
                mat.color = new Color(0.63f, 0.63f, 0.63f);
                break;

            case "c":
                mat.color = new Color(0, 0, 1);
                break;

            case "cc":
                mat.color = new Color(1, .5f, 0);
                break;




        }
    }
}
