using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManager GM;
    private CharacterController controller;
    private Vector3 direction;
    //will be replace the get key to touch
    public float forwardSpeed;
    public float jumpForce;
    public float Gravity = -100;
    [SerializeField] private bool isGrounded = true;
    [Range(-3, 3)] public float value;
    private Vector2 startTouch, swipeDelta;
    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;

    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        GM.playerMovement = this;
        gameObject.GetComponent<PlayerUI>().PMT = this;
        forwardSpeed = 10f;
        jumpForce = 10f;
    }

    private void Update()
    {
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        direction.z = forwardSpeed;
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
                Debug.Log("TAP");
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }        

        if (swipeDelta.magnitude > 125)
        {
            //Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            else
            {
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }

            Reset();
        }
    }

    void FixedUpdate()
    {       
        transform.position = new Vector3(value, transform.position.y, transform.position.z);                
        if (isGrounded)
        {
            if (swipeLeft)
            {
                if (value == 3)
                {
                    return;
                }
                value += 3;
            }
            if (swipeRight)
            {
                if (value == -3)
                {
                    return;
                }
                value -= 3;
            }
            if (swipeUp)
            {
                Jump();
            }
            if (swipeDown)
            {
                //Slide();
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

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
