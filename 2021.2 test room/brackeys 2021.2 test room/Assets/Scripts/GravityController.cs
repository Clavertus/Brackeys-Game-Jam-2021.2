using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject levelManager;

    public int cg; //stands for currentGrav variable from RandomizeGravity.cs

    public string tagType;
    /*  when an object gets hit by a bullet, it gets a tag. 
        'c' ic clockwise
        'cc' is counter-clockwise  */

        //WORKING


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();        
    }


    void Update()
    {

        cg = levelManager.GetComponent<RandomizeGravity>().currentGrav;
        tagType = gameObject.tag;

        switch (cg)
        {

            case 0:
                if (tagType == "Untagged")
                {
                    rb.AddForce(Vector3.down * 9.81f * Time.deltaTime);

                } else if (tagType == "c")
                {
                    rb.AddForce(Vector3.left * 9.81f * Time.deltaTime);
                } else if (tagType == "cc")
                {
                    rb.AddForce(Vector3.right * 9.81f * Time.deltaTime);
                }
                break;


            case 1:
                if (tagType == "Untagged")
                {
                    rb.AddForce(Vector3.left * 9.81f * Time.deltaTime);
                }
                else if (tagType == "c")
                {
                    rb.AddForce(Vector3.up * 9.81f * Time.deltaTime);
                }
                else if (tagType == "cc")
                {
                    rb.AddForce(Vector3.down * 9.81f * Time.deltaTime);
                }
                break;



            case 2:
                if (tagType == "Untagged")
                {
                    rb.AddForce(Vector3.up * 9.81f * Time.deltaTime);

                }
                else if (tagType == "c")
                {
                    rb.AddForce(Vector3.right * 9.81f * Time.deltaTime);
                }
                else if (tagType == "cc")
                {
                    rb.AddForce(Vector3.left * 9.81f * Time.deltaTime);
                }
                break;



            case 3:
                if (tagType == "Untagged")
                {
                    rb.AddForce(Vector3.right * 9.81f * Time.deltaTime);

                }
                else if (tagType == "c")
                {
                    rb.AddForce(Vector3.down * 9.81f * Time.deltaTime);
                }
                else if (tagType == "cc")
                {
                    rb.AddForce(Vector3.up * 9.81f * Time.deltaTime);
                }
                break;

            default:
                if (tagType == "Untagged")
                {
                    rb.AddForce(Vector3.down * 9.81f * Time.deltaTime);

                }
                else if (tagType == "c")
                {
                    rb.AddForce(Vector3.left * 9.81f * Time.deltaTime);
                }
                else if (tagType == "cc")
                {
                    rb.AddForce(Vector3.right * 9.81f * Time.deltaTime);
                }
                break;
        } //assigns certain gravity force based on current gravitational cycle and whether the object is influenced by gravity gun



    }



}
