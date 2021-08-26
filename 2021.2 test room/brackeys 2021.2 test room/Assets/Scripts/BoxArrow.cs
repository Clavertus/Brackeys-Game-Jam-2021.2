using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxArrow : MonoBehaviour
{
    Material mat;
    Quaternion fixedRotation;


    public float t;
    public float rotTime;
    public float rotTimer;
    public bool rotating;

    public int currentGrav;

    public float u;
    public float u_rotTime;
    public float u_rotTimer;
    public bool u_rotating;
    public float currentAngle;
    public float desiredAngle;



    public bool hit;
    public bool alive;
    Color normal;
    Color inverted;

    void Awake()
    {


        normal = new Color(0.06132078f, 1f, 0.7074611f);
        inverted = new Color(0.5011898f, 2f, 0.1254902f);
        alive = true;
        rotTime = .3f;
        u_rotTime = .3f;
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





        u_rotating = GameObject.FindGameObjectWithTag("levelManager").GetComponent<LevelManager>().u_rotating;
        currentGrav = GameObject.FindGameObjectWithTag("levelManager").GetComponent<LevelManager>().currentGrav;

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

                mat.SetFloat("Vector1_77cc5a67daa14c0f91110b1c50a3ac0c", Mathf.Lerp(currentAngle, desiredAngle, u));
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
            mat.SetColor("Color_8c2a769c6ad6436aa9ad558ce44ea7bb", Color.Lerp(normal, inverted, t));

            switch (currentGrav) {

               

                case 0:
                    mat.SetFloat("Vector1_77cc5a67daa14c0f91110b1c50a3ac0c", Mathf.Lerp(0, -180, t));
                    break;

                case 1:
                    mat.SetFloat("Vector1_77cc5a67daa14c0f91110b1c50a3ac0c", Mathf.Lerp(-90, -270, t));
                    break;

                case 2:
                    mat.SetFloat("Vector1_77cc5a67daa14c0f91110b1c50a3ac0c", Mathf.Lerp(-180, 0, t));
                    break;

                case 3:
                    mat.SetFloat("Vector1_77cc5a67daa14c0f91110b1c50a3ac0c", Mathf.Lerp(-270, -90, t));
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
            mat.SetColor("Color_8c2a769c6ad6436aa9ad558ce44ea7bb", Color.Lerp(inverted, normal, t));
            switch (currentGrav)
            {
                case 0:

                    mat.SetFloat("Vector1_77cc5a67daa14c0f91110b1c50a3ac0c", Mathf.Lerp(-180, 0, t));
                    break;

                case 1:
                    mat.SetFloat("Vector1_77cc5a67daa14c0f91110b1c50a3ac0c", Mathf.Lerp(-270, -90, t));
                    break;

                case 2:
                    mat.SetFloat("Vector1_77cc5a67daa14c0f91110b1c50a3ac0c", Mathf.Lerp(0, -180, t));
                    break;

                case 3:
                    mat.SetFloat("Vector1_77cc5a67daa14c0f91110b1c50a3ac0c", Mathf.Lerp(-90, -270, t));
                    break;

            }
        }

    }





}