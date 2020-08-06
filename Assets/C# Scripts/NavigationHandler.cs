﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationHandler : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject creditPanel;

    private void ToggleStartGame()
    {

    }

    private void ToggleSettingPanel()
    {
        settingPanel.SetActive(true);
    }

    private void ToggleCreditPanel()
    {
        creditPanel.SetActive(true);
    }

}
