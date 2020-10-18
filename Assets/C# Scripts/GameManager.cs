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


    void Start()
    {        
        Countdown = 3f;
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<PlayerMovement>().GM = this;
        Player.GetComponent<PlayerUI>().GM = this;
        PD =GameObject.Find("PlayerData").GetComponent<PlayerData>();
        PD.GM = this;
        PD.GetReference();
        health = startHealth;
        HealthBar.fillAmount = health / startHealth;
    }

    void Update()
    {
        GameOver();
        CountdownStartGame();
 
        HealthBar.fillAmount = health / startHealth;
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
