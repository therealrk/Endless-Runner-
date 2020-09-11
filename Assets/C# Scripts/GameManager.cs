using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Video;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public int totalCoin;
    public GameObject gun;
    public float score;
    public int distance;
    private GameObject Player;
    public Button button;
    public string touchobject;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<PlayerMovement>().GM = this;
        Player.GetComponent<PlayerUI>().GM = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log(touch);
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit = new RaycastHit();
        //if (Input.GetMouseButton(0))
        //{
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        Debug.Log(hit.collider.name);
        //    }
        //}
    }

    public void OnClicked(Button button)
    {
        Debug.Log(button.name);
    }

    void ChangeGun()
    {
        
    }

    void BuyGun()
    {
        bool bought=false;
        if (!bought)
        {
            int price = 0;
            if (price < totalCoin)
            {
                
            }
        }
    }

}
