using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IDragHandler, IEndDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int mySpot;

    public Image image;
    public Button button;
    public Text text;

    public InventoryUI ui;

    public void Start()
    {
        ui = FindObjectOfType<InventoryUI>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        image.transform.position = Input.mousePosition;
        image.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.transform.localPosition = Vector3.zero;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (ui == null)
            ui = FindObjectOfType<InventoryUI>();
        UIItem other = eventData.pointerDrag.GetComponent<UIItem>();
        if (other != null)
        {
            Inventory i = ui.playerInventory;
   //       if (i != null)
     //         i.SwapItems(mySpot, other.mySpot);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("pointer enter");
        if(ui == null)
            ui = FindObjectOfType<InventoryUI>();
        Item myItem = ui.playerInventory.items[mySpot];
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void AddItem(Sprite theItem, int amount)
    {
        image.enabled = true;
        image.sprite = theItem;
        text.text = amount + "";
    }

    public void ClearSlot()
    {
        image.enabled = false;
        text.text = "";
    }

}
