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
        munietxt.text = save.currentSave.money + "";
    }
}
