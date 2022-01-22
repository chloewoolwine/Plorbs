using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainmain;
    public GameObject loadPanel;
    public GameObject settingsPanel;
    public GameObject loadingScreen;

    
    public void NewGameStart()
    {
        GameManager.INSTANCE.load = false;
        loadingScreen.gameObject.SetActive(true);
        mainmain.gameObject.SetActive(false);
        GameManager.INSTANCE.UpdateGameState(GameState.Island);
    }

    public void SettingsPanel()
    {
        settingsPanel.gameObject.SetActive(true);
        mainmain.gameObject.SetActive(false);
    }

    public void LoadPanel()
    {
        loadPanel.gameObject.SetActive(true);
        mainmain.gameObject.SetActive(false);

        //load all the save games here. :c
    }
    
}
