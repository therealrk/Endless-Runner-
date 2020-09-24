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
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.name);
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
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
        if (hit.gameObject.tag == "EnemyWeapon")
        {
            Health -= 1;
            Debug.Log("Hit by Enemy weapon");
            Debug.Log("Player Health was deduct");
        }
        if(hit.gameObject.tag == "Money")
        {

        }
    }
}
