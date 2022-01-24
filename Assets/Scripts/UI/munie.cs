using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class munie : MonoBehaviour
{
    public Text munietxt;
    SaveHandler save;

    // Start is called before the first frame update
    void Start()
    {
        save = FindObjectOfType<SaveHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(save == null)
            save = FindObjectOfType<SaveHandler>();
        munietxt.text = SaveHandler.INSTANCE.currentSave.money + "";
    }
}
