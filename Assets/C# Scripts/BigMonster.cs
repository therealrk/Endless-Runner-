using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMonster : MonoBehaviour
{
    private float Forward;
    public PlayerMovement playerMovement;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Monster = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Forward >= 0)
        {
            Forward -= 0.1f;
        }
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        direction.z = playerMovement.forwardSpeed;
    }

    public void JumpForward()
    {
        Forward += 100f;
    }
}
