using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerUI playerUI;
    public PlayerData PD;
    public int totalCoin;
    public GameObject currGun;
    private List<GameObject> Guns = new List<GameObject>();
    public enum Gun {Pistol,SMG,Rifle,Shotgun}
    public Gun gun;
    public float score;
    public int distance;
    private GameObject Player;
    public Button button;
    public string touchobject;
    public enum GamePhase { Mainmenu,InGame, GameOver}
    public GamePhase gamePhase;
    public GameObject losePanel;
    public GameObject ingamePanel;
    public GameObject pausePanel;
    public bool pauseGame = false;

    //UI stuffs
    public Image HealthBar; 
    private float health;
    public float startHealth = 3;
    private float Countdown;
    public GameObject CDTimer;


    // Start is called before the first frame update
    void Start()
    {        
        Countdown = 3f;
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<PlayerMovement>().GM = this;
        Player.GetComponent<PlayerUI>().GM = this;
        PD =GameObject.Find("PlayerData").GetComponent<PlayerData>();
        PD.GM = this;
        PD.GetReference();
        //GameObject Holster = GameObject.FindGameObjectWithTag("Gun");
        //foreach (GameObject gun in Holster.transform)
        //{
        //    Guns.Add(gun);
        //}

        health = startHealth;
        HealthBar.fillAmount = health / startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        CountdownStartGame();

        HealthBar.fillAmount = health / startHealth;
        //test hp
        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }
        */
    }

    public void GameOver()
    {
        if(gamePhase == GamePhase.InGame)
        {
            if (playerUI.GameOver == true)
            {
                ingamePanel.SetActive(false);
                losePanel.SetActive(true);
                gamePhase = GamePhase.GameOver;
                Debug.Log("GameOver!");
                
            }
        }        
    }

    public void OnClicked(Button button)
    {
        Debug.Log(button.name);
        if(button.GetComponentInChildren<Text>().text!="Bought"|| button.GetComponentInChildren<Text>().text != "Current Gun")
        {
            if (button.name == "Pistol")
            {
                BuyGun(button,Gun.Pistol);
            }
            else if (button.name == "SMG")
            {
                BuyGun(button,Gun.SMG);
            }
            else if (button.name == "Rifle")
            {
                BuyGun(button, Gun.Rifle);
            }
            else if (button.name == "Shotgun")
            {
                BuyGun(button, Gun.Shotgun);
            }
        }
        else
        {
            if (button.name == "Pistol")
            {
                ChangeGun(button, Gun.Pistol);
            }
            else if (button.name == "SMG")
            {
                ChangeGun(button, Gun.SMG);
            }
            else if (button.name == "Rifle")
            {
                ChangeGun(button, Gun.Rifle);
            }
            else if (button.name == "Shotgun")
            {
                ChangeGun(button, Gun.Shotgun);
            }
        }
    }

    void ChangeGun(Button button,Gun gun)
    {
        if (button.GetComponentInChildren<Text>().text == "Bought")
        {
            if (gun == Gun.Pistol)
            {
                foreach(GameObject weapon in Guns)
                {
                    weapon.SetActive(false);
                }
                currGun = Guns[0];
                Guns[0].SetActive(true);
            }
            else if (gun == Gun.SMG)
            {
                foreach (GameObject weapon in Guns)
                {
                    weapon.SetActive(false);
                }
                currGun = Guns[1];
                Guns[1].SetActive(true);
            }
            else if (gun == Gun.Rifle)
            {
                foreach (GameObject weapon in Guns)
                {
                    weapon.SetActive(false);
                }
                currGun = Guns[2];
                Guns[2].SetActive(true);
            }
            else if (gun == Gun.Shotgun)
            {
                foreach (GameObject weapon in Guns)
                {
                    weapon.SetActive(false);
                }
                currGun = Guns[3];
                Guns[3].SetActive(true);
            }
        }       
    }

    void BuyGun(Button button,Gun gun)
    {
        if (gun == Gun.Pistol)
        {
            int price = 100;
            button.GetComponentInChildren<Text>().text = price.ToString();
            if (price < totalCoin)
            {
                button.GetComponentInChildren<Text>().text = "Bought";
            }
        }
        else if(gun == Gun.SMG)
        {
            int price = 100;
            button.GetComponentInChildren<Text>().text = price.ToString();
            if (price < totalCoin)
            {
                button.GetComponentInChildren<Text>().text = "Bought";
            }
        }
        else if (gun == Gun.Rifle)
        {
            int price = 100;
            button.GetComponentInChildren<Text>().text = price.ToString();
            if (price < totalCoin)
            {
                button.GetComponentInChildren<Text>().text = "Bought";
            }
        }
        else if (gun == Gun.Shotgun)
        {
            int price = 100;
            button.GetComponentInChildren<Text>().text = price.ToString();
            if (price < totalCoin)
            {
                button.GetComponentInChildren<Text>().text = "Bought";
            }
        }
    }

    public void CountdownStartGame()
    {
        CDTimer.GetComponent<Text>().text = (((int)Countdown).ToString());
        if (Countdown >= 0)
        {
            Countdown -= Time.deltaTime;
        }
        else
        {
            CDTimer.SetActive(false);
            Player.GetComponent<PlayerMovement>().enabled= true;
        }
    }

    //UI functions
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void PauseGame()
    {
        if (pauseGame == false)
        {
            Time.timeScale = 0;
            ingamePanel.SetActive(false);
            pausePanel.SetActive(true);
            pauseGame = true;
        }


    }

    public void ResumeGame()
    {
        if (pauseGame == true)
        {
            Time.timeScale = 1;
            ingamePanel.SetActive(true);
            pausePanel.SetActive(false);
            pauseGame = false;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

}
