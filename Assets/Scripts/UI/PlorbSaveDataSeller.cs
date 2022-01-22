using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlorbSaveDataSeller : MonoBehaviour
{
    SaveHandler sv;
    // Start is called before the first frame update
    void Start()
    {
        sv = FindObjectOfType<SaveHandler>();
    }

    internal void SellPlorb(PlorbSaveData plorb)
    {
        sv.currentSave.money += plorb.value;

        sv.currentSave.plorbs.Remove(plorb);
    }
}
