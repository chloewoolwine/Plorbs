using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory playerInventory;

    int size;

    public UIItem[] slots;
    public GameObject slotHolder;
    public Transform selection;

    public Sprite tempSprite;

    public bool inventoryEnabled;

    private void Start()
    {
        inventoryEnabled = false;
        GetSlots();
      //playerInventory.inventoryChanged.AddListener(RefreshInventory);
    }

    private void GetSlots()
    {
        size = playerInventory.inventorySize;
        slots = new UIItem[size];
        for (int x = 0; x < size; x++)
        {
            slots[x] = slotHolder.transform.GetChild(x).GetComponentInChildren<UIItem>();
        }
        slotHolder.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventoryEnabled) { TurnOn(); } else { TurnOff(); }
        }
    }
    /*
    private void RefreshInventory()
    {
        //print(playerInventory.items.Count);
        for (int x = 0; x < size; x++)
        {
            if (playerInventory.items[x].id != -1)
            {
                if (playerInventory.items[x].sprite != null)
                    slots[x].AddItem(playerInventory.items[x].sprite, playerInventory.items[x].quantity);
                else
                    slots[x].AddItem(tempSprite, playerInventory.items[x].quantity);
            }
            else
            {
                slots[x].ClearSlot();
            }
        }


    */

    private void TurnOn()
    {
        slotHolder.SetActive(true);
        inventoryEnabled = true;
        Time.timeScale = 0;
    }
    private void TurnOff()
    {
        slotHolder.SetActive(false);
        inventoryEnabled = false;
        Time.timeScale = 1;
    }
}
