using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buymenu : MonoBehaviour
{
    SaveHandler sv;
    public int paintCost;
    public int polyCost;
    public int pixelCost;

    // Start is called before the first frame update
    void Start()
    {
        sv = FindObjectOfType<SaveHandler>();
    }

    public void BuyPaintEgg()
    {
        if(sv.currentSave.money > paintCost)
        {
            sv.currentSave.money -= paintCost;
            MakePlorbSaveOfType(BodyStyle.Paint);
        } else
        {
            //lol
        }
    }

    public void BuyPolyEgg()
    {
        if (sv.currentSave.money > polyCost)
        {
            sv.currentSave.money -= polyCost;
            MakePlorbSaveOfType(BodyStyle.Poly);
        }
        else
        {
            //lol
        }
    }

    public void BuyPixelEgg()
    {
        if (sv.currentSave.money > pixelCost)
        {
            sv.currentSave.money -= pixelCost;
            MakePlorbSaveOfType(BodyStyle.Pixel);
        }
        else
        {
            //lol
        }
    }

    public void MakePlorbSaveOfType(BodyStyle type)
    {
        PlorbSaveData data = new PlorbSaveData();
        data.age = 0;
        
        data.body = (BodyStyle)type;
        data.wing = (WingStyle)type;
        data.ear = (EarStyle)type;
        data.eye = (EyeStyle)type;
        //create genes
        data.genes = PlorbDefiner.CommonGenesOfType(type);

        data.r = Random.Range(0f, 1f);
        data.g = Random.Range(0f, 1f);
        data.b = Random.Range(0f, 1f);

        // data.title = DetermineTitle(data);
        // data.value = DetermineValue(data);
        //  newPlorb.GetComponent<PlorbAnimator>().ResetHue();
        //need to put plorbs in an organized spot in the scene- maybe parent to this object?

        data.x = 0;
        data.y = 0;

        sv.currentSave.plorbs.Add(data);
    }

}
