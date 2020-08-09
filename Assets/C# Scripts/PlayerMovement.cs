using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //will be replace the get key to touch
    [Range(-3, 3)] public float value;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(value, transform.position.y, transform.position.z);

        if (Input.GetButtonDown("Right"))
        {
            if (value == 3)
            {
                return;
            }
            value += 3;
        }
        if (Input.GetButtonDown("Left"))
        {
            if (value == -3)
            {
                return;
            }
            value -= 3;
        }
    }
}
