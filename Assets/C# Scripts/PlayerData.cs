using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public GameManager GM;
    public int totalCoin;
    public GameObject currGun;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        GM.PD = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
