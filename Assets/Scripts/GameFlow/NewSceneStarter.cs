using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == "Cave")
        {
            //route money  to the player manager
            PlayerManager.INSTANCE.Money = SaveHandler.INSTANCE.currentSave.money;
            //do other things if neccesary
        } else if(currentScene.name == "Island")
        {
            //if we are not starting a new game
            if(SaveHandler.INSTANCE.currentSave != null)
            {
                PlayerManager.INSTANCE.Money = SaveHandler.INSTANCE.currentSave.money;
                //route the plorbs
                List<PlorbSaveData> plorbs = SaveHandler.INSTANCE.currentSave.plorbs;

                foreach(PlorbSaveData x in plorbs)
                {
                    PlorbDefiner.INSTANCE.CreatePlorbFromSave(x);
                }

            } else
            {
                //do the tutorial
            }
        }
    }
    
}
