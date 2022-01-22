using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager INSTANCE;

    private int money;
    public int Money
    {
        get { return money; }
        set
        {
            money = value;
            //update UI
            moneyText.text = money + "";
        }
    }

    public Text moneyText;

    public List<Item> inventory;
    public static int inventoryCapacity = 6;

    private GameManager gm;


    private void Start()
    {
        INSTANCE = this;
        //some logic here for loading an old save i guess?
        gm = FindObjectOfType<GameManager>();
        if (gm.load) DoLoadGame(FindObjectOfType<SaveHandler>());
        else StartNewGame();
    }

    public void DoLoadGame(SaveHandler save)
    {
        this.money = save.currentSave.money;
    }
    
    public void StartNewGame()
    {
        moneyText.text = money + "";
    }

    private void Update()
    {
        moneyText.text = money + "";
    }
}
