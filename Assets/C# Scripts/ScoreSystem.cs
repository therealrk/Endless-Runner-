using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Text scoreCurrent;
    public Text scoreFinal;
    public float scoreAmount;
    public float pointIncreasedPerSec;
    public PlayerUI PUI;

    void Start()
    {
        scoreAmount = 0f;
        pointIncreasedPerSec = 10f;
    }

    void Update()
    {
        if (PUI.GameOver == false)
        {
            scoreCurrent.text = (int)scoreAmount + "KM";
            scoreAmount += pointIncreasedPerSec * Time.deltaTime;
        }
        if (PUI.GameOver == true)
        {
            scoreFinal.text = scoreCurrent.text;
            Debug.Log(scoreFinal + "Stop");
        }
    }
}
