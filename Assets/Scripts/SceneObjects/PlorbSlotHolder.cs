using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlorbSlotHolder : MonoBehaviour
{

    public bool isHoldingPlorb;
    public PlorbData myPlorb;

    public bool plorbHovered;
    public PlorbData hoveringPlorb;

    public bool IsHoldingPlorb
    {
        get { return isHoldingPlorb; }
        set
        {
            isHoldingPlorb = value;
            OnHoldingChange?.Invoke(value);
        }
    }

    public delegate void OnHoldingChangeDelegate(bool newVal);
    public event OnHoldingChangeDelegate OnHoldingChange;

    void Update()
    {
        if (plorbHovered)
        {
            //add animations here
            if (Input.GetMouseButtonUp(0))
            {
                IsHoldingPlorb = true;
                myPlorb = hoveringPlorb;
                myPlorb.gameObject.transform.position = this.gameObject.transform.position;
                myPlorb.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                myPlorb.GetComponent<PlorbInteractions>().StopAllCoroutines();
                plorbHovered = false;
                hoveringPlorb = null;
            }
        }
        if (myPlorb == null) isHoldingPlorb = false;
    }

    public void ForceRemovePlorb()
    {
        isHoldingPlorb = false;
        myPlorb = null;
        plorbHovered = false;
        hoveringPlorb = null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Plorb" && !IsHoldingPlorb)
        {
            plorbHovered = true;
            hoveringPlorb = other.GetComponent<PlorbData>();
        }
    }
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plorb" && IsHoldingPlorb)
        {
            PlorbData plorbCheck = collision.GetComponent<PlorbData>();

            if(plorbCheck == myPlorb)
            {
                IsHoldingPlorb = false;
                myPlorb = null; //goodbye friend.
            }
        }
        plorbHovered = false;
        hoveringPlorb = null;
    }
}
