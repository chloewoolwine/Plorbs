using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Inventory : MonoBehaviour
{
    public List<Item> items;
    public int inventorySize;

    public UnityEvent inventoryChanged = new UnityEvent();

    public int trueCount;
    public int SelectedSlot;
    
    // Start is called before the first frame update
    /*
    public bool AddItem(Item i)
    {
        Item find = items.FirstOrDefault(item => item.id == i.id);
        if(find != null)
        {
            find.quantity += i.quantity;
            inventoryChanged.Invoke();
            return true;
        }
        if(trueCount < inventorySize)
        {
            Item emptySpot = items.Find(item => item.id == -1);
            emptySpot.MorphItem(i);
            inventoryChanged.Invoke();
            trueCount++;
            return true;
        }
        return false;
    }

    //todo- test. it might break because if i = null
    //this is a fucking mess
    public bool RemoveItem(Item i)
    {
        Item find = items.FirstOrDefault(item => item.id == i.id);
        if (find == null || find.quantity < i.quantity)
            return false;
        find.quantity -= i.quantity;
        if(find.quantity == 0)
        {
            find.MorphItem(data.GetItem(-1));//turn into an empty slot
            trueCount--;
        }
        inventoryChanged.Invoke();
        return true;
    }

    public bool SwapItems(int i1, int i2)
    {
        if (i1 > inventorySize || i2 > inventorySize)
            return false;
        Item temp = items[i1];
        items[i1] = items[i2];
        items[i2] = temp;
        inventoryChanged.Invoke();
        return true;
    }

    public bool SaveInventory()
    {
        throw new NotImplementedException("lol you havent made a save function yet pleb");
    }*/
   
}
