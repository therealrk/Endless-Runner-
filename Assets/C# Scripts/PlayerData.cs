using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public GameManager GM;
    public int totalCoin=0;
    public GameObject currGun;
    public PlayerMovement PM;
    // Start is called before the first frame update
    
    void Start()
    {        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetReference()
    {
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        GM.PD = this;
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        PM.Data = this;
    }
}
