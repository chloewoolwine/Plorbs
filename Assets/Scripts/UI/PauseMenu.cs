using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu INSTANCE;

    private bool gameIsPaused;
    public GameObject pauseMenu;
    // Update is called once per frame

    private void Awake()
    {
        INSTANCE = this;
        gameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            print("pause");
            if (gameIsPaused) Resume(); else Pause();
        }
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        GameManager.INSTANCE.UpdateGameState(GameState.Pause);
    }

    private void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        GameManager.INSTANCE.UpdateGameState(GameState.InGame);
    }

    public void SaveButton()
    {
        //no such capability available.
    }

    public void PauseButton()
    {
        Pause();
    }

    public void ResumeButton()
    {
        Resume();
    }

    public void HelpButton()
    {
    }

    public void SettingsButton()
    {
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
