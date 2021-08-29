using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxArrow : MonoBehaviour
{
    public Material mat;
    Quaternion fixedRotation;
    public Texture frozenMat;
    public Texture normalMat;

     float thawTime;
     float currthaw;



     float t;
     float rotTime;
     float rotTimer;
     bool rotating;

     public string rotation;
     string color;
     string texture;

      public bool evil;

     int currentGrav;

     float u;
     float u_rotTime;
     float u_rotTimer;
     bool u_rotating;

     float v;
     float v_rotTime;
     float v_rotTimer;
     bool v_rotating;

     float currentAngle;
     float desiredAngle;



     public bool hit;
     public bool alive;


    Color normal;
    Color inverted;
    Color frozen;

    public GameObject freezevfx;

    void Awake()
    {

        thawTime = 5f;
        if (!evil)
        {
            normal = new Color(0.06132078f, 1f, 0.7074611f);
            inverted = new Color(0.5011898f, 2f, 0.1254902f);
            frozen = new Color(0.7457621f, 0.4552854f, 2.757729f);

            rotation = "Vector1_77cc5a67daa14c0f91110b1c50a3ac0c";
            color = "Color_8c2a769c6ad6436aa9ad558ce44ea7bb";
            texture = "Texture2D_711f0d4e17f343b0af6bbdfb3c684eca";

        } else
        {
            normal = new Color(0.3384325f, 0.2834639f, 0.9245283f);
            inverted = new Color(1, 0.07903025f, 0f);
            frozen = new Color(0.7457621f, 0.4552854f, 2.757729f);

            rotation = "Vector1_77cc5a67daa14c0f91110b1c50a3ac0c";
            color = "Color_8c2a769c6ad6436aa9ad558ce44ea7bb";
            texture = "Texture2D_711f0d4e17f343b0af6bbdfb3c684eca";
        }

        


        alive = true;
        rotTime = .3f;
        u_rotTime = .3f;
        v_rotTime = .3f;
        mat = gameObject.GetComponent<MeshRenderer>().material;
        fixedRotation = transform.rotation;
        u_rotating = false;

    }



    void LateUpdate()
    {
        if (alive)
            transform.rotation = fixedRotation;


    }

    void Update()
    {




        if (GameObject.FindGameObjectWithTag("levelManager") != null)
        {
            u_rotating = GameObject.FindGameObjectWithTag("levelManager").GetComponent<LevelManager>().u_rotating;
            currentGrav = GameObject.FindGameObjectWithTag("levelManager").GetComponent<LevelManager>().currentGrav;
        }

        if (u_rotating)
        {



            if (u_rotTimer < u_rotTime)
            {
                u_rotTimer += Time.deltaTime;
                u = u_rotTimer / u_rotTime;
                u = 1 - Mathf.Pow(2, -10 * u);
            }
            else
            {
                u_rotTimer = 0;
                u_rotating = false;
            }




            if (tag == "Untagged")
            {
                switch (currentGrav)
                {
                    case 0:
                        currentAngle = -270;
                        desiredAngle = 0;
                        break;

                    case 1:
                        currentAngle = 0;
                        desiredAngle = -90;
                        break;

                    case 2:
                        currentAngle = -90;
                        desiredAngle = -180;
                        break;

                    case 3:
                        currentAngle = -180;
                        desiredAngle = -270;
                        break;

                }
            }
            else
            {
                switch (currentGrav)
                {
                    case 0:
                        currentAngle = -90;
                        desiredAngle = -180;
                        break;

                    case 1:
                        currentAngle = -180;
                        desiredAngle = -270;
                        break;

                    case 2:
                        currentAngle = -270;
                        desiredAngle = 0;
                        break;

                    case 3:
                        currentAngle = 0;
                        desiredAngle = -90;
                        break;

                }

            }

                mat.SetFloat(rotation, Mathf.Lerp(currentAngle, desiredAngle, u));
        }








        if (tag == "Inverted" && hit)
        {

            do
            {

                rotating = true;
            } while (2 < 1); // so only once

            if (rotating)
            {
                if (rotTimer < rotTime)
                {
                    rotTimer += Time.deltaTime;
                    t = rotTimer / rotTime;
                    t = 1 - Mathf.Pow(2, -10 * t);

                }
                else
                {
                    rotTimer = 0;
                    rotating = false;
                    hit = false;
                }
            }
            mat.SetColor(color, Color.Lerp(normal, inverted, t));

            switch (currentGrav) {

               

                case 0:
                    mat.SetFloat(rotation, Mathf.Lerp(0, -180, t));
                    break;

                case 1:
                    mat.SetFloat(rotation, Mathf.Lerp(-90, -270, t));
                    break;

                case 2:
                    mat.SetFloat(rotation, Mathf.Lerp(-180, 0, t));
                    break;

                case 3:
                    mat.SetFloat(rotation, Mathf.Lerp(-270, -90, t));
                    break;
            }

        }


        if (tag == "Untagged" && hit)
        {
            do
            {

                rotating = true;
            } while (2 < 1); // so only once

            if (rotating)
            {
                if (rotTimer < rotTime)
                {
                    rotTimer += Time.deltaTime;
                    t = rotTimer / rotTime;
                    t = 1 - Mathf.Pow(2, -10 * t);
                }
                else
                {
                    rotTimer = 0;
                    rotating = false;
                    hit = false;
                }
            }
            mat.SetColor(color, Color.Lerp(inverted, normal, t));
            switch (currentGrav)
            {
                case 0:

                    mat.SetFloat(rotation, Mathf.Lerp(-180, 0, t));
                    break;

                case 1:
                    mat.SetFloat(rotation, Mathf.Lerp(-270, -90, t));
                    break;

                case 2:
                    mat.SetFloat(rotation, Mathf.Lerp(0, -180, t));
                    break;

                case 3:
                    mat.SetFloat(rotation, Mathf.Lerp(-90, -270, t));
                    break;

            }
        }

        if(tag == "Frozen" && hit)
        {
            mat.SetTexture(texture, frozenMat);
            currthaw = 0;

            

            do
            {

                v_rotating = true;
            } while (2 < 1); // so only once

            if (v_rotating)
            {
                if (v_rotTimer < v_rotTime)
                {
                    v_rotTimer += Time.deltaTime;
                    v = v_rotTimer / v_rotTime;
                    v = 1 - Mathf.Pow(2, -10 * v);
                }
                else
                {
                    v_rotTimer = 0;
                    v_rotating = false;
                    hit = false;
                }
            }


           mat.SetColor(color, 
               Color.Lerp(mat.GetColor(color), frozen, v));
        }

        if(tag == "Frozen")
        {
            

            if (currthaw < thawTime)
            {
                currthaw += Time.deltaTime;
            }
            else
            {
                freezevfx.SetActive(false);
                mat.SetColor(color, normal);
                mat.SetTexture(texture, normalMat);
                switch (currentGrav)
                {
                    case 0:
                        mat.SetFloat(rotation, 0);
                        break;

                    case 1:
                        mat.SetFloat(rotation, -90);

                        break;

                    case 2:
                        mat.SetFloat(rotation, -180);

                        break;

                    case 3:
                        mat.SetFloat(rotation, -270);

                        break;
                }
                gameObject.transform.parent.parent.tag = "Untagged";
                gameObject.tag = "Untagged";

            }
        }
    }





}