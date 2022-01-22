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
        LeanTween.reset();

        switch (state)
        {
            case GameState.Menu:
                //idk
                break;

            case GameState.Pause:

                break;

            case GameState.Island:
                if (load)
                {
                    SceneManager.LoadSceneAsync("Game");
                } else
                {
                    SceneManager.LoadSceneAsync("Game");
                }
                break;
            case GameState.Cave:
                //show loading screen
                //cave load
                //get data for cave
                state = GameState.Cave;
                SaveHandler.INSTANCE.CreateSave();
                SceneManager.LoadSceneAsync("Cave");
                break;
            case GameState.Shop:
                state = GameState.Cave;
                SaveHandler.INSTANCE.CreateSave();
                SceneManager.LoadSceneAsync("Shop");
                break;
        }

        OnStateChange?.Invoke(newState);
    }
}

public enum GameState
{
    Menu,
    Pause,
    Island,
    Cave,
    Shop
}
