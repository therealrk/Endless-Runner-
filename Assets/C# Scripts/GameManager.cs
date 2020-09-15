using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Video;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public int totalCoin;
    public GameObject currGun;
    private GameObject selectGun;
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
        if(button.GetComponentInChildren<Text>().text!="Bought"|| button.GetComponentInChildren<Text>().text != "Current Gun")
        {
            if (button.name == "Pistol")
            {
                BuyGun(button,"pistol");
            }
            else if (button.name == "SMG")
            {
                BuyGun(button,"smg");
            }
            else if (button.name == "Rifle")
            {
                BuyGun(button,"rifle");
            }
            else if (button.name == "Shotgun")
            {
                BuyGun(button, "shotgun");
            }
            else if (button.name == "")
            {
                BuyGun(button,"");
            }
        }
        else
        {
            ChangeGun(button);
        }
    }

    void ChangeGun(Button button)
    {
        if (button.GetComponentInChildren<Text>().text == "Bought")
        {
            if (button.name == "pistol")
            {
            }
        }       
    }

    void BuyGun(Button button,string gun)
    {
        if (gun == "pistol")
        {
            int price = 100;
            button.GetComponentInChildren<Text>().text = price.ToString();
            if (price < totalCoin)
            {
                button.GetComponentInChildren<Text>().text = "Bought";
            }
        }
        else if(gun == "smg")
        {
            int price = 100;
            button.GetComponentInChildren<Text>().text = price.ToString();
            if (price < totalCoin)
            {
                button.GetComponentInChildren<Text>().text = "Bought";
            }
        }
        else if (gun == "rifle")
        {
            int price = 100;
            button.GetComponentInChildren<Text>().text = price.ToString();
            if (price < totalCoin)
            {
                button.GetComponentInChildren<Text>().text = "Bought";
            }
        }
        else if (gun == "shotgun")
        {
            int price = 100;
            button.GetComponentInChildren<Text>().text = price.ToString();
            if (price < totalCoin)
            {
                button.GetComponentInChildren<Text>().text = "Bought";
            }
        }
    }

}
