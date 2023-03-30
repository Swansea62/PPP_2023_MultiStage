using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource backgroundMusic;

    bool play;

    bool toggleChange;


    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();

        play = true;
    }

    void Update()
    {
        if (play == true && toggleChange == true)
        {
            backgroundMusic.Play();
        }

        if (play == false && toggleChange == true)
        {
            backgroundMusic.Stop();
            toggleChange = false;
        }
    }
}
