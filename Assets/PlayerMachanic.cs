using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class PlayerMachanic : MonoBehaviour
{
    public GameObject enemyObj;
    public bool GameOver = false;
    public PlayerMovement PMT;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Transport")
        {
            PMT.forwardSpeed = 0f;
            GameOver = true;
            Debug.Log("Hit By Transportation!");
            Debug.Log(GameOver);
        }
        if (collision.gameObject.tag == "EnemyWeapon")
        {
            Debug.Log("Hit by Enemy weapon");
            Debug.Log("Player Health was deduct");
        }
    }

}
