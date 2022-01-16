using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Game Manager script. Holds game state and handles scene transfers.
public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;

    public GameState state;

    public static event Action<GameState> OnStateChange;

    public bool load;
    public int saveGameNum;


    private void Awake()
    {
        if(INSTANCE != null)
        {
            Destroy(this.gameObject);
        }
        INSTANCE = this;
        UpdateGameState(GameState.Menu);
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        //do splash screens here.
        
        SceneManager.LoadSceneAsync("MainMenu");
    }


    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (state)
        {
            case GameState.Menu:
                //idk
                break;

            case GameState.Pause:

                break;

            case GameState.InGame:
                if (load)
                {

                } else
                {
                    SceneManager.LoadSceneAsync("Game");
                }
                break;
        }

        OnStateChange?.Invoke(newState);
    }
}

public enum GameState
{
    Menu,
    Pause,
    InGame
}
