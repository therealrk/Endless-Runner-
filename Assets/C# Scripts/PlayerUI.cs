using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameManager GM;
    public int Health = 3;
    public int Coin;
    public int Ammo;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        GM.playerUI = this;
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {

        }
    }
}
