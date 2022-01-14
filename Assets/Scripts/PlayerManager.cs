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

    private void Awake()
    {
        INSTANCE = this;
        //some logic here for loading an old save i guess?
        StartNewGame();
    }

    public void DoLoadGame()
    {

    }

    public void StartNewGame()
    {
        moneyText.text = money + "";
    }
}
