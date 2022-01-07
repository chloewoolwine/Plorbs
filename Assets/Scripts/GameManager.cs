using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Game Manager script. Holds game state and handles scene transfers.
public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;

    public GameState state;

    public static event Action<GameState> OnStateChange;


    private void Awake()
    {
        INSTANCE = this;
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
