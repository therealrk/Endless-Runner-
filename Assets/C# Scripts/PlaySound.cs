using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource sound_click;
    public AudioSource sound_confirm;
    public AudioSource sound_BGM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void playClickSound()
    {
        sound_click.Play();
    }

    public void playConfirmSound()
    {
        sound_confirm.Play();
    }

    public void playBGM()
    {
        sound_BGM.Play();

    }
}
