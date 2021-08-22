using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public SpriteRenderer sprite;

    void Update()
    {
        switch (tag)
        {
            case "Untagged":
                sprite.color = new Color(0.63f, 0.63f, 0.63f);
                break;

            case "c":
                sprite.color = new Color(1, 0, 0);
                break;

            case "cc":
                sprite.color = new Color(0, 0, 1);
                break;




        }
    }
}
