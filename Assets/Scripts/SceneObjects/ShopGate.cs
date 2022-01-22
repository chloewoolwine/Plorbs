using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGate : MonoBehaviour
{
    public SimpleButton mybutton;

    // Start is called before the first frame update
    void Start()
    {
        mybutton.mousedown += GoToStore;
    }

    private void GoToStore()
    {
        GameManager.INSTANCE.UpdateGameState(GameState.Shop);
    }
}
