using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlorbLister : MonoBehaviour
{
    public List<PlorbSaveData> plorbsToList;

    private PlorbData[] toiletOnly;

    public ListSingleElement blank;
    public GameObject listParent;

    public void ListPlorbs()
    {
        blank.gameObject.SetActive(true);
        for (int x = 0; x < plorbsToList.Count; x++)
        {
            GameObject clone = Instantiate(blank.gameObject, Vector3.zero, Quaternion.identity, listParent.transform);
            ListSingleElement element = clone.GetComponent<ListSingleElement>();

            element.ShowPlorb(plorbsToList[x]);
            //map button to destroy plorb
            element.button.onClick.RemoveAllListeners(); //should be fine bc buttons are being dynamically created but idk just in case i guess

            if(GameManager.INSTANCE.state == GameState.Island)
            {
                AddDeathListener(element.button, toiletOnly[x]);
            } else if(GameManager.INSTANCE.state == GameState.Cave)
            {
                AddJuiceListener(element.button, plorbsToList[x], FindObjectOfType<PlorbJuicer>());
            } else if(GameManager.INSTANCE.state == GameState.Shop)
            {
                AddSellListener(element.button, plorbsToList[x]);
            }

            AddDestroyListener(element.button, element);
        }
        blank.gameObject.SetActive(false);
    }

    void AddSellListener(Button b, PlorbSaveData plorb)
    {
        b.onClick.AddListener(() => GetComponent<PlorbSaveDataSeller>().SellPlorb(plorb));
    }

    void AddJuiceListener(Button b, PlorbSaveData plorb, PlorbJuicer juicer)
    {
        b.onClick.AddListener(() => juicer.JuicePlorb(plorb));
    }

    void AddDestroyListener(Button b, ListSingleElement e)
    {
        b.onClick.AddListener(() => Destroy(e.gameObject));
    }

    void AddDeathListener(Button b, PlorbData value)
    {
        b.onClick.AddListener(() => PlorbDefiner.INSTANCE.DestroyPlorb(value));
    }

    public void UpdatePlorbs()
    {
        plorbsToList.Clear();
        print("plorbs bein updated");
        print(GameManager.INSTANCE.state + " state");
        if(GameManager.INSTANCE.state == GameState.Island)
        {
            toiletOnly = PlorbDefiner.INSTANCE.GetComponentsInChildren<PlorbData>();
            plorbsToList = new List<PlorbSaveData>();
            print(toiletOnly.Length + " plorbs found");
            for(int x = 0; x < toiletOnly.Length; x++)
            {
                plorbsToList.Add(SaveHandler.INSTANCE.SavePlorb(toiletOnly[x]));
            }
        } else { plorbsToList = SaveHandler.INSTANCE.currentSave.plorbs; }

        ListPlorbs();
    }

    public void CloseMe()
    {
        foreach(ListSingleElement x in listParent.GetComponentsInChildren<ListSingleElement>())
        {
            if(x != blank)
                Destroy(x.gameObject);
        }

        gameObject.SetActive(false);
    }
}
