using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlorbSeller : MonoBehaviour
{

    public PlorbSlotHolder trigger;

    public SimpleButton sellButton;

    // Start is called before the first frame update
    void Start()
    {
        sellButton.mousedown += SellPlorb;
    }

    
    private void SellPlorb()
    {
        if(trigger.myPlorb != null)
        {
            PlayerManager.INSTANCE.Money = PlayerManager.INSTANCE.Money + trigger.myPlorb.value;
            PlorbDefiner.INSTANCE.SellPlorb(trigger.myPlorb);
            trigger.ForceRemovePlorb();
        }
    }
}
