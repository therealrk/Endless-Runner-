using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationHandler : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject creditPanel;
    public GameManager GM;

    public void ToggleStartGame()
    {
        SceneManager.LoadSceneAsync("GameMatch");
    }

    public void ToggleSettingPanel()
    {
        settingPanel.SetActive(true);
    }

    public void ToggleCreditPanel()
    {
        creditPanel.SetActive(true);
    }

    public void ToggleRestartGame()
    {
        GM.RestartGame();
    }

    public void ToggleExitToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void ToggleExitGame()
    {
        Application.Quit();
    }

}
