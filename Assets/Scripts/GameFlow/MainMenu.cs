using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainmain;
    public GameObject loadPanel;
    public GameObject settingsPanel;
    public GameObject loadingScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NewGameStart()
    {
        GameManager.INSTANCE.load = false;
        loadingScreen.gameObject.SetActive(true);
        mainmain.gameObject.SetActive(false);
        GameManager.INSTANCE.UpdateGameState(GameState.InGame);
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
