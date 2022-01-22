using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gobacktoisland : MonoBehaviour
{
    public GameManager gm;
    public SaveHandler sv;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        sv = FindObjectOfType<SaveHandler>();
    }

    public void clickbutton()
    {
        print("go");
        gm.load = true;
        gm.UpdateGameState(GameState.Island);
    }
}
