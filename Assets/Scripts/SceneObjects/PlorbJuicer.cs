using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlorbJuicer : MonoBehaviour
{
    public SimpleButton button;
    public PlorbLister list;

    public Animator juicepart;
    public Animator plorbpart;

    private SaveHandler sv;
    
    private void Start()
    {
        button.mousedown += OpenMenu;
    }

    public void CloseMenu()
    {
        list.gameObject.SetActive(false);
        this.GetComponent<Collider2D>().enabled = true;
    }

    public void OpenMenu()
    {
        list.gameObject.SetActive(true);
        list.UpdatePlorbs();
        this.GetComponent<Collider2D>().enabled = false;
    }

    public void JuicePlorb(PlorbSaveData x)
    {
        if (sv == null)
            sv = FindObjectOfType<SaveHandler>();


        sv.currentSave.money += (int)(x.value * (x.currentJuice/x.totalJuiceCapacity));
        juicepart.Play("juicer");
        x.currentJuice = 0;
    }



}
