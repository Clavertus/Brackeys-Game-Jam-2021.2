using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject levelManager;

    public int currentGravitationState;
    int cg;
    public float gravityScale;

   

    public string tagType;
    /*  when an object gets hit by a bullet, it gets a tag. 
        'c' ic clockwise
        'cc' is counter-clockwise  */

    //WORKING


    void Start()
    {
        gravityScale = 20;
        if(gameObject.name == "Player")
        {
            rb.WakeUp();
            gravityScale = 10;
        }
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
        levelManager = GameObject.FindGameObjectWithTag("levelManager");
    }


    void Update()
    {


        currentGravitationState = cg;
        cg = levelManager.GetComponent<LevelManager>().currentGrav;
        tagType = gameObject.tag;

        #region oldCode
        /*
        switch (cg)
        {

            case 0:
                if (tagType == "Untagged")
                {
                    rb.AddForce(Vector3.down * 9.81f * Time.deltaTime * gravityScale);

                } else if (tagType == "c")
                {
                    rb.AddForce(Vector3.left * 9.81f * Time.deltaTime * gravityScale);
                } else if (tagType == "cc")
                {
                    rb.AddForce(Vector3.right * 9.81f * Time.deltaTime * gravityScale);
                }
                break;


            case 1:
                if (tagType == "Untagged")
                {
                    rb.AddForce(Vector3.left * 9.81f * Time.deltaTime * gravityScale);
                }
                else if (tagType == "c")
                {
                    rb.AddForce(Vector3.up * 9.81f * Time.deltaTime * gravityScale);
                }
                else if (tagType == "cc")
                {
                    rb.AddForce(Vector3.down * 9.81f * Time.deltaTime * gravityScale);
                }
                break;



            case 2:
                if (tagType == "Untagged")
                {
                    rb.AddForce(Vector3.up * 9.81f * Time.deltaTime * gravityScale);

                }
                else if (tagType == "c")
                {
                    rb.AddForce(Vector3.right * 9.81f * Time.deltaTime * gravityScale);
                }
                else if (tagType == "cc")
                {
                    rb.AddForce(Vector3.left * 9.81f * Time.deltaTime * gravityScale);
                }
                break;



            case 3:
                if (tagType == "Untagged")
                {
                    rb.AddForce(Vector3.right * 9.81f * Time.deltaTime * gravityScale);

                }
                else if (tagType == "c")
                {
                    rb.AddForce(Vector3.down * 9.81f * Time.deltaTime * gravityScale);
                }
                else if (tagType == "cc")
                {
                    rb.AddForce(Vector3.up * 9.81f * Time.deltaTime * gravityScale);
                }
                break;

            default:
                if (tagType == "Untagged")
                {
                    rb.AddForce(Vector3.down * 9.81f * Time.deltaTime * gravityScale);

                }
                else if (tagType == "c")
                {
                    rb.AddForce(Vector3.left * 9.81f * Time.deltaTime * gravityScale);
                }
                else if (tagType == "cc")
                {
                    rb.AddForce(Vector3.right * 9.81f * Time.deltaTime * gravityScale);
                }
                break;
        } //assigns certain gravity force based on current gravitational cycle and whether the object is influenced by gravity gun

    */

        #endregion

        switch (cg)
        {

            case 0:
                if (tagType == "Untagged")
                {
                    rb.AddForce(Vector3.down * 9.81f * Time.fixedDeltaTime * gravityScale);

                }
                else if (tagType == "Inverted")
                {
                    rb.AddForce(Vector3.down * 9.81f * Time.fixedDeltaTime * -gravityScale);
                }

                break;


            case 1:
                if (tagType == "Untagged")
                {
                    rb.AddForce(Vector3.left * 9.81f * Time.fixedDeltaTime * gravityScale);

                }
                else if (tagType == "Inverted")
                {
                    rb.AddForce(Vector3.left * 9.81f * Time.fixedDeltaTime * -gravityScale);
                }
                break;



            case 2:
                if (tagType == "Untagged")
                {
                    rb.AddForce(Vector3.up * 9.81f * Time.fixedDeltaTime * gravityScale);

                }
                else if (tagType == "Inverted")
                {
                    rb.AddForce(Vector3.up * 9.81f * Time.fixedDeltaTime * -gravityScale);
                }
                break;



            case 3:
                if (tagType == "Untagged")
                {
                    rb.AddForce(Vector3.right * 9.81f * Time.fixedDeltaTime * gravityScale);

                }
                else if (tagType == "Inverted")
                {
                    rb.AddForce(Vector3.right * 9.81f * Time.fixedDeltaTime * -gravityScale);
                }
                break;

            default:
                if (tagType == "Untagged")
                {
                    rb.AddForce(Vector3.down * 9.81f * Time.fixedDeltaTime * gravityScale);

                }
                else if (tagType == "Inverted")
                {
                    rb.AddForce(Vector3.down * 9.81f * Time.fixedDeltaTime * -gravityScale);
                }
                break;

        }



    }

    
}
