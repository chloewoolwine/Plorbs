using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightClickMenu : MonoBehaviour, IPointerExitHandler
{
    public PlorbData currentPlorb;
    private PlorbAI ai;

    public GameObject buttons;

    public Camera cam;

    public static RightClickMenu INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }

    public void Update()
    {
        if(currentPlorb != null)
        {
            ai.currentAction = PlorbAI.Action.JackShit;
        }
    }

    public void DoOpenAnimation()
    {
        //do animation here lol
    }

    public void MoveToPlorb(PlorbData plorb)
    {
        buttons.transform.position = cam.WorldToScreenPoint(plorb.transform.position);
        currentPlorb = plorb;
        ai = currentPlorb.GetComponent<PlorbAI>();
        DoOpenAnimation();
    }

    public void EscapePlorb()
    {
        currentPlorb = null;
        buttons.transform.position = new Vector3(-750f, 750f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        EscapePlorb();
    }
    
    public void FeedPlorb()
    {
        currentPlorb.Feed(20);
    }

    public void PetPlorb()
    {
        currentPlorb.Pet(10);
    }

    

}
