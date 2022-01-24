using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainmain;
    public GameObject loadPanel;
    public GameObject settingsPanel;
    public GameObject loadingScreen;
    public GameObject listParent;
    public GameObject blankbutton;

    public string saveGameName;
    public string[] listofsaves;


    private void Start()
    {
        listofsaves = SaveHandler.GetGameSaveLists();
        for(int x = 0; x < listofsaves.Length; x++)
        {
            listofsaves[x] = listofsaves[x].Substring(0, listofsaves[x].LastIndexOf("."));
        }
    }

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

    public void CloseSettingsPanel()
    {
        settingsPanel.gameObject.SetActive(false);
        mainmain.gameObject.SetActive(true);
    }

    public void LoadPanel()
    {
        loadPanel.gameObject.SetActive(true);
        mainmain.gameObject.SetActive(false);

        blankbutton.gameObject.SetActive(true);

        foreach(string x in listofsaves)
        {
            GameObject buttonclose = Instantiate(blankbutton.gameObject, Vector3.zero, Quaternion.identity, listParent.transform);
            buttonclose.GetComponentInChildren<Text>().text = x;
            AddClickNameListener(buttonclose.GetComponent<Button>(), x);
        }

        blankbutton.gameObject.SetActive(false);

    }

    void AddClickNameListener(Button b, string word)
    {
        b.onClick.AddListener(() => SetSaveGameName(word));
    }

    void SetSaveGameName(string s)
    {
        saveGameName = s;
    }

    public void CloseLoadPanel()
    {
        loadPanel.gameObject.SetActive(false);
        mainmain.gameObject.SetActive(true);
    }

    public void LoadGameStart()
    {
        GameManager.INSTANCE.load = true;
        GameManager.INSTANCE.savegamename = saveGameName;
        SaveHandler.INSTANCE.currentSave = (GameSave)SaveHandler.DeserializeData(saveGameName);
        loadingScreen.gameObject.SetActive(true);
        mainmain.gameObject.SetActive(false);
        GameManager.INSTANCE.UpdateGameState(GameState.Island);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

}
