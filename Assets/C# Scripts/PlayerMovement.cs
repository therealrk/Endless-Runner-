using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManager GM;
    private CharacterController controller;
    private Vector3 direction;
    //will be replace the get key to touch
    public float forwardSpeed;
    public float jumpForce;
    public float Gravity = -20;
    private GameObject GameManager;
    [Range(-3, 3)] public float value;

    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        GameManager.GetComponent<GameManager>().playerMovement = this;
        controller = gameObject.GetComponent<CharacterController>();
        forwardSpeed = 5f;
        jumpForce = 10f;
    }

    private void Update()
    {
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        direction.z = forwardSpeed;
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
      
        }
        controller.Move(direction * Time.fixedDeltaTime);
        transform.position = new Vector3(value, transform.position.y, transform.position.z);
                
        if (controller.isGrounded)
        {
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
            if (Input.GetButtonDown("Up"))
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }
}
