using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    GameManager gm;

    public GameObject tutorialGUI;
    public GameObject she;
    public GameObject BIGSHE;
    public Text tutorialtext;

    public int tutorialphase;
    public int spotToGiveEgg;
    public int zonespot;
    public List<string> phasetext;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        if (!gm.load)
        {
            tutorialGUI.gameObject.SetActive(true);
        }
    }

    public void clickthetutorial()
    {
        if(tutorialphase == zonespot)
        {
            DoJoke();
        } 
        if(tutorialphase == zonespot + 1)
        {
            EndJoke();
        }
        if (tutorialphase == spotToGiveEgg)
        {
            PlorbDefiner.MakeTutorialEgg();
        }
        if (tutorialphase == phasetext.Count)
        {
            tutorialGUI.SetActive(false);
        } else
        {
            tutorialtext.text = phasetext[tutorialphase];
            tutorialphase++;
        }

    }

    private void DoJoke()
    {
        BIGSHE.SetActive(true);
        she.SetActive(false);
    }

    private void EndJoke()
    {
        BIGSHE.SetActive(false);
        she.SetActive(true);
    }
    
}
