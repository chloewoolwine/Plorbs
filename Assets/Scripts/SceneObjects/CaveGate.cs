using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGate : MonoBehaviour
{
    public SimpleButton mybutton;

    // Start is called before the first frame update
    void Start()
    {
        mybutton.mousedown += GoToCave;
    }

    private void GoToCave()
    {
        GameManager.INSTANCE.UpdateGameState(GameState.Cave);
    }
}
