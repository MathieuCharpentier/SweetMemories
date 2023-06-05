using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUnpauseMusic : MonoBehaviour
{
    public AudioSource musicSource;
    bool paused = true;
    bool firstTime = true;

    public void PauseUnpause()
    {
        if(paused)
        {
            if(firstTime)
            {
                musicSource.Play();
                firstTime = false;
            }
            else
            musicSource.UnPause();
            paused = false;
        }
        else
        {
            musicSource.Pause();
            paused = true;
        }
    }
}
