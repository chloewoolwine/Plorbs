using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopbuttonmappingz : MonoBehaviour
{

    public GameObject buyMenu;
    public GameObject sellMenu;
    public GameObject defaultmenu;
    public GameObject convoMenu;

    public PlorbLister plorblist;

    public bool ConvoOccuring;
    int convonum;

    public List<string> greetings;
    public Text girltxt;

    public string convoReturnText;
    public List<string> conversation;

    // Start is called before the first frame update
    void Start()
    {
        girltxt.text = greetings[Random.Range(0, greetings.Count)];
    }

    public void ContinueConvo()
    {
        if(convonum == 0)
        {
            ConvoOccuring = true;
        } else if(convonum == conversation.Count)
        {
            ConvoOccuring = false;
            ConvoMenuOff();
            return;
        }
        girltxt.text = conversation[convonum];
        convonum++;
    }

    public void ConvoMenuOff()
    {
        convoMenu.SetActive(false);
        defaultmenu.SetActive(true);
        girltxt.text = convoReturnText;
    }

    public void ConvoMenuOn()
    {
        convonum = 0;
        convoMenu.SetActive(true);
        defaultmenu.SetActive(false);
        ContinueConvo();
    }

    public void BuyEggMenuOn()
    {
        defaultmenu.SetActive(false);
        buyMenu.SetActive(true);
    }

    public void SellMenuOn()
    {
        defaultmenu.SetActive(false);
        sellMenu.SetActive(true);

        plorblist.UpdatePlorbs();
    }

    public void BuyEggMenuOff()
    {
        defaultmenu.SetActive(true);
        buyMenu.SetActive(false);
    }

    public void SellMenuOff()
    {
        defaultmenu.SetActive(true);
        sellMenu.SetActive(false);
    }


}
