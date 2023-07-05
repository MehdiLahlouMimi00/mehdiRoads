using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTheGame : MonoBehaviour
{

    public GameObject PauseUI;

    public void Pause()
    {
        Time.timeScale = 0f;    // The game is now pauzed
        PauseUI.SetActive(true);

    }


    public void Resume()
    {
        Time.timeScale = 1f;
        PauseUI.SetActive(false);
    }
}
