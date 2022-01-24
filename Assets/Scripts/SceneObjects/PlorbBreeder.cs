using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlorbBreeder : MonoBehaviour
{
    public PlorbSlotHolder trigger1;
    public PlorbSlotHolder trigger2;

    public int sexcooldown;

    public SimpleButton heartbutton;

    private void Start()
    {
        trigger1.OnHoldingChange += CheckForTwo;
        trigger2.OnHoldingChange += CheckForTwo;

        heartbutton.mousedown += GenerateEgg;
    }

    private void CheckForTwo(bool val)
    {
        heartbutton.gameObject.SetActive(trigger1.IsHoldingPlorb && trigger2.IsHoldingPlorb);
    }

    private void GenerateEgg()
    {
        PlorbData parent1 = trigger1.myPlorb;
        PlorbData parent2 = trigger2.myPlorb;

        //check to make sure both plorbs are not eggs
        if (parent1.Age < 10 || parent2.Age < 10)
            return;
        if (parent1.sexcooldown > 0 || parent2.sexcooldown > 2)
            return;

        parent1.sexcooldown = sexcooldown;
        parent2.sexcooldown = sexcooldown;

        GameObject egg = PlorbDefiner.INSTANCE.BreedPlorbs(parent1.gameObject, parent2.gameObject);

    }
}
