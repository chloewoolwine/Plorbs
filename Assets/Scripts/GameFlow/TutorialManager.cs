using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    GameManager gm;

    public GameObject tutorialGUI;
    public Text tutorialtext;

    public int tutorialphase;
    public int spotToGiveEgg;
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
    
}
