using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    //will be replace the get key to touch
    public float forwardSpeed = 5f;
    public float jumpForce = 10f;
    public float Gravity = -20;
    [Range(-3, 3)] public float value;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        direction.z = forwardSpeed;
        direction.y += Gravity * Time.deltaTime;
    }

    void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
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

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Up"))
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }
}
