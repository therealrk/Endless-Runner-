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
    private float playerSpeed =2f;
    public float Gravity = -9.18f;
    [Range(-3, 3)] public float value;
    private Vector2 startTouch,endTouch, swipeDelta;
    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    [SerializeField] private bool groundedPlayer = false;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();        
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        GM.playerMovement = this;
        gameObject.GetComponent<PlayerUI>().PMT = this;
        forwardSpeed = 5f;
        jumpForce = 10f;
    }

    private void Update()
    {
        //transform.position = new Vector3(value, transform.position.y, transform.position.z);

        controller.Move(direction * Time.deltaTime);

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Input.GetMouseButton(0))
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.tag == "Enemy")
                        {
                            Destroy(hit.transform.gameObject);
                        }
                    }
                }
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
                Jump();
                Debug.Log("TAP");
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                endTouch = Input.touches[0].position;
                isDraging = false;
                swipeDelta = endTouch - startTouch;
                Reset();
            }

        }        

        if (swipeDelta.magnitude > 125)
        {
            //Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (controller.isGrounded)
            {
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    if (x < 0)
                    {
                        swipeLeft = true;
                        Debug.Log("left");
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
            }

            Reset();
        }
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(value, transform.position.y, transform.position.z);
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        direction.z = forwardSpeed;
        direction.y += Gravity * Time.deltaTime;



        //groundedPlayer = controller.isGrounded;
        //if (groundedPlayer && direction.y < 0)
        //{
        //    direction.y = 0f;
        //}

        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //controller.Move(move * Time.deltaTime * playerSpeed);

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        //// Changes the height position of the player..
        //if (Input.GetButtonDown("Jump") && groundedPlayer)
        //{
        //    direction.y += Mathf.Sqrt(jumpForce * -3.0f * Gravity);
        //}

        //controller.Move(direction * Time.deltaTime);

        if (controller.isGrounded)
        {
            direction.y = 1;
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
        //else
        //{
        //    direction.y += Gravity * Time.deltaTime;
        //}
        //Debug.Log(direction);
        //controller.Move(direction * Time.fixedDeltaTime);

    }

    private void Jump()
    {
        // Changes the height position of the player..
        if (groundedPlayer)
        {
            direction.y += Mathf.Sqrt(jumpForce * -3.0f * Gravity);
            groundedPlayer = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundedPlayer = true;
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

}
