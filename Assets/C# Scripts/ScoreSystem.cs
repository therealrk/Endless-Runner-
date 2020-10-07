using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Text scoreCurrent;
    public Text scoreFinal;
    public float scoreAmount;
    public float distance;
    public int distances;
    public float pointIncreasedPerSec;
    public int distanceindent;
    public PlayerUI PUI;

    void Start()
    {
        scoreAmount = 0f;
        pointIncreasedPerSec = 10f;
        distances = 100;
        distanceindent = 1;
    }

    void Update()
    {
        if (PUI.GameOver == false)
        {
            scoreCurrent.text = (int)scoreAmount + "P";
            scoreAmount += pointIncreasedPerSec * Time.deltaTime;
            distance += pointIncreasedPerSec / 100;
            if(distance>= 4 * distanceindent * distances)
            {
                distanceindent += 1;
            }
        }
        if (PUI.GameOver == true)
        {
            scoreFinal.text = scoreCurrent.text;
            Debug.Log(scoreFinal + "Stop");
        }
    }
}
