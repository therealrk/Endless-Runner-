using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region References
    public GameManager GM;
    private CharacterController controller;
    public PlayerData Data;
    public ScoreSystem scoreSystem;
    public BigMonster Monster;
    #endregion
    private Vector3 direction;
    //will be replace the get key to touch
    public float forwardSpeed;
    public float jumpForce;
    private float playerSpeed =2f;
    public float Gravity = -9.18f;
    [Range(-3f, 3f)] public float value;
    private Vector2 startTouch,endTouch, swipeDelta;
    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    [SerializeField] private bool groundedPlayer = false;
    public GameObject Player;
    public bool power;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        //Monster = GameObject.FindGameObjectWithTag("Monster").GetComponent<BigMonster>();
        GM.playerMovement = this;
        gameObject.GetComponent<PlayerUI>().PMT = this;
        //Monster.playerMovement = this;
        forwardSpeed = 5f;
        jumpForce = 6f;
        value = 0f;
        Data = GM.PD;
    }

    private void Update()
    {
        transform.position = new Vector3(value, transform.position.y, transform.position.z);
        controller.Move(direction * Time.deltaTime);
        groundedPlayer = controller.isGrounded;
        if (Input.GetMouseButtonDown(0))
        {
            startTouch = Input.mousePosition;
            tap = true;
            isDraging = true;

        }

        //Reser Distance, get the new swipeDelta
        if (Input.GetMouseButtonUp(0))
        {
            endTouch = Input.mousePosition;
            swipeDelta = endTouch - startTouch;
        }
        if (startTouch == Vector2.zero && Input.GetMouseButtonUp(0))
        {
            Fire();
        }


        float deltax = swipeDelta.x;
        float deltay = swipeDelta.y;
        if (swipeDelta.magnitude > 125)
        {
            //Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (groundedPlayer)
            {
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    if (x < 0)
                    {
                        swipeLeft = true;
                        if (value <= -3f)
                        {
                            value = -3f;
                            return;
                        }
                        else
                        {
                            value -= 3f;

                        }
                        Reset();

                    }
                    else
                    {
                        swipeRight = true;
                        if (value >= 3f)
                        {
                            value = 3f;
                            return;
                        }
                        else
                        {
                            value += 3f;
                        }
                        Reset();
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

        }
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(value, transform.position.y, transform.position.z);

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

        if (groundedPlayer)
        {
            direction.y = 1;
            if (swipeLeft)
            {
                Debug.Log("GOINGRIGHT");
                

            }
            if (swipeRight)
            {
                Debug.Log("GOINGLEFT");
                

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
            Reset();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Data.totalCoin += 1;
            scoreSystem.scoreAmount += 20;
            Destroy(other.gameObject);
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        swipeUp = swipeRight = swipeLeft = swipeDown = false;
        isDraging = false;
    }

    private void Fire()
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
    }

    private void POWAR()
    {
        
    }
}
