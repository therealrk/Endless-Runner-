using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameManager GM;
    public int Health = 3;
    public int Coin;
    public int Ammo;
    [SerializeField] private Text _health, _coin, _ammo;
    public GameObject enemyObj;
    public bool GameOver = false;
    public PlayerMovement PMT;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        GM.playerUI = this;
        GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().PUI = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WeaponFire()
    {
        if (Ammo > 0)
        {
            Ammo -= 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Transport")
        {
            PMT.forwardSpeed = 0f;
            GameOver = true;
            Debug.Log("Hit By Transportation!");
            Debug.Log(GameOver);
        }
    }
}
