using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlorbDefiner : MonoBehaviour
{
    //2 steps
    //1. create a new PlorbPrefab (should have all scripts attatched and ready)
    //2. populate the PlorbData

    public static PlorbDefiner INSTANCE;
    public GameObject blankPlorbPrefab;
    
    //public List<PlorbData> deadPlorbs;

    private void Awake()
    {
        INSTANCE = this;
    }

    public void MagicalPlorbButton()
    {
        CreateRandomPlorbOfType((BodyStyle)Random.Range(0,3));
    }

    public void TrashFirstPlorbISee()
    {
        DestroyPlorb(GetComponentInChildren<PlorbData>());
    }

    public GameObject CreateRandomPlorbOfType(BodyStyle type)
    {
        GameObject newPlorb = BlankPlorb();
        PlorbData data = newPlorb.GetComponent<PlorbData>();

        //set body info
        data.body = (BodyStyle)type;
        data.wing = (WingStyle)type;
        data.ear = (EarStyle)type;
        //create genes
        data.genes = CommonGenesOfType(type);

        data.hue = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        data.title = DetermineTitle(data);
        data.value = DetermineValue(data);
        newPlorb.GetComponent<PlorbAnimator>().ResetHue();
        //need to put plorbs in an organized spot in the scene- maybe parent to this object?


        newPlorb.transform.parent = this.gameObject.transform;
        return newPlorb;
    }

    public PlorbGenes CommonGenesOfType(BodyStyle type)
    {
        switch (type)
        {
            case BodyStyle.Paint: //at least one has to be paint but one or two can be pixel
                return new PlorbGenes(BodyStyle.Paint, Random.Range(0f, 1f) > .5f ? BodyStyle.Paint: BodyStyle.Pixel, 
                    WingStyle.Paint, Random.Range(0f, 1f) > .5f ? WingStyle.Paint : WingStyle.Pixel, 
                    EarStyle.Paint, Random.Range(0f, 1f) > .5f ? EarStyle.Paint : EarStyle.Pixel);

            case BodyStyle.Pixel:
                return new PlorbGenes(BodyStyle.Pixel, BodyStyle.Pixel, WingStyle.Pixel, WingStyle.Pixel, EarStyle.Pixel, EarStyle.Pixel);

            case BodyStyle.Poly: //poly is dominant so can have any genes as long as one of them is poyl
                PlorbGenes temp = new PlorbGenes(BodyStyle.Poly, BodyStyle.Poly, WingStyle.Poly, WingStyle.Poly, EarStyle.Poly, EarStyle.Poly);

                float f1 = Random.Range(0f, 1f);
                float f2 = Random.Range(0f, 1f);
                float f3 = Random.Range(0f, 1f);

                if (f1 > .5f){ temp.body2 = f1 > .8f ? BodyStyle.Pixel : BodyStyle.Paint;}
                if (f2 > .5f) { temp.wing2 = f2 > .8f ? WingStyle.Pixel : WingStyle.Paint; }
                if (f3 > .5f) { temp.ear2 = f3 > .8f ? EarStyle.Pixel : EarStyle.Paint; }
                return temp;
        }

        throw new System.Exception("Illegal State, Failed generating PlorbGenes of new Plorb");
    }

    private string DetermineTitle(PlorbData plorb)
    {
        return "";
    }

    //make return type here

    private int DetermineValue(PlorbData plorb)
    {
        return 100;
    }

    private void DetermineDecayValues(PlorbData plorb)
    {
        plorb.happinessDecayRate = 1;
        plorb.hungerDecayRate = 1;
        plorb.juiceIncreaseRate = 1;
        plorb.totalJuiceCapacity = 100;
        plorb.juiceExplosionThreshold = 100;
    }

    public void DestroyPlorb(PlorbData plorb)
    {
        //should remove it from list and add it to dead list
    //    deadPlorbs.Add(CopyPlorbData(plorb));
        Destroy(plorb.gameObject);
    }

    private PlorbData CopyPlorbData(PlorbData plorb)
    {
        PlorbData data = new PlorbData()
        {
            hue = new Color(plorb.hue.r, plorb.hue.g, plorb.hue.b, 1f),
            title = plorb.title,
            name = plorb.name
        };
        return data;
    }

    public GameObject BreedPlorbs(GameObject plorb1, GameObject plorb2)
    {
        PlorbData parent1 = plorb1.GetComponent<PlorbData>();
        PlorbData parent2 = plorb2.GetComponent<PlorbData>();

        GameObject child = PunnetSquare(parent1, parent2);

        return CreateRandomPlorbOfType(BodyStyle.Pixel);
    }

    //JUST punnet squares, ONLY SETS GENES, doesnt set the traits correctly
    private GameObject PunnetSquare(PlorbData plorb1, PlorbData plorb2)
    {
        GameObject childPlorb = BlankPlorb();
        PlorbData childData = childPlorb.GetComponent<PlorbData>();

        int b1 = Random.Range(0, 2), b2 = Random.Range(0, 2), w1 = Random.Range(0, 2), w2 = Random.Range(0, 2), e1 = Random.Range(0, 2), e2 = Random.Range(0, 2);

        if (b1 == 0) childData.genes.body1 = plorb1.genes.body1; else childData.genes.body1 = plorb1.genes.body2;
        if (b2 == 0) childData.genes.body2 = plorb2.genes.body1; else childData.genes.body2 = plorb2.genes.body2;

        if (w1 == 0) childData.genes.wing1 = plorb1.genes.wing1; else childData.genes.wing1 = plorb1.genes.wing2;
        if (w2 == 0) childData.genes.wing2 = plorb2.genes.wing1; else childData.genes.wing2 = plorb2.genes.wing2;

        if (e1 == 0) childData.genes.ear1 = plorb1.genes.ear1; else childData.genes.ear1 = plorb1.genes.ear2;
        if (e2 == 0) childData.genes.ear2 = plorb2.genes.ear1; else childData.genes.ear2 = plorb2.genes.ear2;



        return childPlorb;
    }

    private BodyStyle setBody(PlorbData plorb)
    {
        List<BodyStyle> temp = new List<BodyStyle>{ plorb.genes.body1, plorb.genes.body2 };

        if (temp.Contains(BodyStyle.Poly)) return BodyStyle.Poly;
        else if (temp.Contains(BodyStyle.Paint)) return BodyStyle.Paint;
        else return BodyStyle.Pixel;
    }

    private GameObject BlankPlorb() { return (GameObject)Instantiate(blankPlorbPrefab, new Vector3(0, 0, 0), Quaternion.identity); }
}

