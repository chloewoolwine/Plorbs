using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour
{
    public SimpleButton mybutton;
    public PlorbLister list;

    // Start is called before the first frame update
    void Start()
    {
        mybutton.mousedown += GoToCave;
    }

    private void GoToCave()
    {
        list.gameObject.SetActive(true);
        list.UpdatePlorbs();
    }

    public void CloseList()
    {
        list.gameObject.SetActive(false);
    }
}
