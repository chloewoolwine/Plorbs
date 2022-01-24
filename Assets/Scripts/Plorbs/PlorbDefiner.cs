using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlorbDefiner : MonoBehaviour
{

    public float SATURATION_CAP;

    public static PlorbDefiner INSTANCE;
    public GameObject blankPlorbPrefab;

    private GameManager gm; 
    
    //public List<PlorbData> deadPlorbs;

    private void Awake()
    {
        INSTANCE = this;
    }

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        if (gm.load == true)
        {
            foreach(PlorbSaveData save in SaveHandler.INSTANCE.currentSave.plorbs)
            {
                CreatePlorbFromSave(save);
            }
        }
    }

    internal static void MakeTutorialEgg()
    {
        INSTANCE.CreateRandomPlorbOfType(BodyStyle.Paint);
    }

    public void MagicalPlorbButton()
    {
        GameObject x = CreateRandomPlorbOfType((BodyStyle)Random.Range(0,3));
    }

    public void TrashFirstPlorbISee()
    {
        DestroyPlorb(GetComponentInChildren<PlorbData>());
    }

    public GameObject CreateRandomPlorbOfType(BodyStyle type)
    {
        GameObject newPlorb = BlankPlorb();
        PlorbData data = newPlorb.GetComponent<PlorbData>();
        data.Age = 0;

        //set body info
        data.body = (BodyStyle)type;
        data.wing = (WingStyle)type;
        data.ear = (EarStyle)type;
        data.eye = (EyeStyle)type;
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

    public GameObject CreatePlorbFromSave(PlorbSaveData save)
    {
        GameObject newPlorb = BlankPlorb();
        PlorbData data = newPlorb.GetComponent<PlorbData>();

        data.body = save.body;
        data.wing = save.wing;
        data.ear = save.ear;
        data.eye = save.eye;
        data.genes = save.genes;
        data.Age = save.age;

        data.totalJuiceCapacity = save.totalJuiceCapacity;
        data.happinessDecayRate = save.happinessDecayRate;
        data.hungerDecayRate = save.hungerDecayRate;
        data.CurrentJuice = save.currentJuice;
        data.hunger = save.hunger;
        data.happiness = save.happiness;
        data.deathState = save.deathState;

        data.hue = new Color(save.r, save.g, save.b);
        data.title = save.title;
        data.name = save.givenName;
        data.value = save.value;
        newPlorb.GetComponent<PlorbAnimator>().ResetHue();

        newPlorb.transform.parent = this.gameObject.transform;

        newPlorb.transform.position = new Vector3(save.x, save.y);

        Debug.Log(save.hunger + " " + save.happiness + " " + save.currentJuice);
        Debug.Log(data.hunger + " " + data.happiness + " " + data.currentJuice);


        return newPlorb;
    }

    public static PlorbGenes CommonGenesOfType(BodyStyle type)
    {
        switch (type)
        {
            case BodyStyle.Paint: //at least one has to be paint but one or two can be pixel
                return new PlorbGenes(BodyStyle.Paint, Random.Range(0f, 1f) > .5f ? BodyStyle.Paint : BodyStyle.Pixel,
                    WingStyle.Paint, Random.Range(0f, 1f) > .5f ? WingStyle.Paint : WingStyle.Pixel,
                    EarStyle.Paint, Random.Range(0f, 1f) > .5f ? EarStyle.Paint : EarStyle.Pixel,
                    EyeStyle.Paint, Random.Range(0f, 1f) > .5f ? EyeStyle.Paint : EyeStyle.Pixel);

            case BodyStyle.Pixel:
                return new PlorbGenes(BodyStyle.Pixel, BodyStyle.Pixel, WingStyle.Pixel, WingStyle.Pixel, EarStyle.Pixel, EarStyle.Pixel, EyeStyle.Pixel, EyeStyle.Pixel);

            case BodyStyle.Poly: //poly is dominant so can have any genes as long as one of them is poyl
                PlorbGenes temp = new PlorbGenes(BodyStyle.Poly, BodyStyle.Poly, WingStyle.Poly, WingStyle.Poly, EarStyle.Poly, EarStyle.Poly, EyeStyle.Poly, EyeStyle.Poly);

                float f1 = Random.Range(0f, 1f);
                float f2 = Random.Range(0f, 1f);
                float f3 = Random.Range(0f, 1f);

                if (f1 > .5f){ temp.body2 = f1 > .8f ? BodyStyle.Pixel : BodyStyle.Paint;}
                if (f2 > .5f) { temp.wing2 = f2 > .8f ? WingStyle.Pixel : WingStyle.Paint; }
                if (f3 > .5f) { temp.ear2 = f3 > .8f ? EarStyle.Pixel : EarStyle.Paint; }
                if (f3 > .5f) { temp.eye2 = f3 > .8f ? EyeStyle.Pixel : EyeStyle.Paint; }
                return temp;
        }

        throw new System.Exception("Illegal State, Failed generating PlorbGenes of new Plorb");
    }

    private string DetermineTitle(PlorbData plorb)
    {
        return "";
    }
    
    private int DetermineValue(PlorbData plorb)
    {
        int val = 0;

        switch (plorb.body)
        {
            case BodyStyle.Paint:
                val += 200;
                break;
            case BodyStyle.Pixel:
                val += 300;
                break;
            case BodyStyle.Poly:
                val += 100;
                break;
        }

        switch (plorb.wing)
        {
            case WingStyle.Paint:
                val += 100;
                break;
            case WingStyle.Pixel:
                val += 150;
                break;
            case WingStyle.Poly:
                val += 50;
                break;
        }

        switch (plorb.ear)
        {
            case EarStyle.Paint:
                val += 100;
                break;
            case EarStyle.Pixel:
                val += 150;
                break;
            case EarStyle.Poly:
                val += 50;
                break;
        }
        //eyes have no bearing on value.

        //TODO: some kind of algorithm for color cost??

        return val;
    }

    private void DetermineDecayValues(PlorbData plorb)
    {
        plorb.happinessDecayRate = 1;
        plorb.hungerDecayRate = 1;
        plorb.juiceIncreaseRate = 1;
        plorb.totalJuiceCapacity = 100;
    }

    public void DestroyPlorb(PlorbData plorb)
    {
        //should remove it from list and add it to dead list
        //    deadPlorbs.Add(CopyPlorbData(plorb));
        PlorbAnimator anim = plorb.GetComponent<PlorbAnimator>();
        anim.onDeath();
        Destroy(plorb.gameObject,.5f);

        
    }

    public void SellPlorb(PlorbData plorb)
    {
        DestroyPlorb(plorb); //lol probably play a different animation instead before destroying
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
        PlorbData myData = child.GetComponent<PlorbData>();

        SetStyles(myData);

        DiscoverColor(parent1, parent2, myData);

        //seting secondary values
        myData.title = DetermineTitle(myData);
        myData.value = DetermineValue(myData);

        child.GetComponent<PlorbAnimator>().ResetHue();

        child.transform.parent = this.gameObject.transform;
        
        PrintPlorbGenesDebug(parent1);
        PrintPlorbGenesDebug(parent2);
        PrintPlorbGenesDebug(myData);

        return child;
    }

    private void PrintPlorbGenesDebug(PlorbData plorb)
    {
        print("r: " + plorb.hue.r + "    g: " + plorb.hue.g + "    b: " + plorb.hue.b);
        print("genotype: body-" + plorb.genes.body1 + plorb.genes.body2 + " wing-" + plorb.genes.wing1 + plorb.genes.wing2 + " ear-" + plorb.genes.ear1 + plorb.genes.ear2
            + "\n" + "phenotype: body-+ " + plorb.body + " wing-" + plorb.wing + " ear-" + plorb.ear);
    }

    //right now just averages the colors. This is LAME however, change later
    //TODO: make this less lame.
    private void DiscoverColor(PlorbData parent1, PlorbData parent2, PlorbData child)
    {
        float chance = Random.Range(0f, 1f);

        Color result = new Color(0, 0, 0, 0);

        if (chance >= .75f) //parent 1 
            result.r = GetResultedColorFromParent(parent1, parent1.hue.r);
        else if (chance >= .5f) //parent 2 
            result.r = GetResultedColorFromParent(parent2, parent2.hue.r);
        else { //mix of both
            result.r += parent1.hue.r;
            result.r += parent2.hue.r;
            result.r /= 2;
        }

        chance = Random.Range(0f, 1f);
        if (chance >= .75f) //parent 1 
            result.g = GetResultedColorFromParent(parent1, parent1.hue.g);
        else if (chance >= .5f) //parent 2 
            result.g = GetResultedColorFromParent(parent2, parent2.hue.g);
        else
        { //mix of both
            result.g += parent1.hue.g;
            result.g += parent2.hue.g;
            result.g /= 2;
        }

        chance = Random.Range(0f, 1f);
        if (chance >= .75f) //parent 1 
            result.b = GetResultedColorFromParent(parent1, parent1.hue.b);
        else if (chance >= .5f) //parent 2 
            result.b = GetResultedColorFromParent(parent2, parent2.hue.b);
        else
        { //mix of both
            result.b += parent1.hue.b;
            result.b += parent2.hue.b;
            result.b /= 2;
        }
        child.hue = result;
    }

    private float GetResultedColorFromParent(PlorbData parent, float color)
    {
        float result = color;

        switch (parent.body)
        {
            case BodyStyle.Pixel:
                result += Random.Range(.20f, .30f);
                if (result > 1f) result = 1f;
                break;
            case BodyStyle.Paint:
                break;
            case BodyStyle.Poly:
                result -= Random.Range(.20f, .30f);
                if (result < SATURATION_CAP) result = SATURATION_CAP;
                break;
        }

        return result;
    }

    //JUST punnet squares, ONLY SETS GENES, doesnt set the phenotype correctly
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
        
        if (e1 == 0) childData.genes.eye1 = plorb1.genes.eye1; else childData.genes.eye1 = plorb1.genes.eye2;
        if (e2 == 0) childData.genes.eye2 = plorb2.genes.eye1; else childData.genes.eye2 = plorb2.genes.eye2;

        return childPlorb;
    }

    private void SetStyles(PlorbData plorb)
    {
        plorb.body = SetBody(plorb);
        plorb.wing = SetWing(plorb);
        plorb.ear = SetEar(plorb);
        plorb.eye = SetEye(plorb);
    }

    private BodyStyle SetBody(PlorbData plorb)
    {
        List<BodyStyle> temp = new List<BodyStyle>{ plorb.genes.body1, plorb.genes.body2 };

        if (temp.Contains(BodyStyle.Poly)) return BodyStyle.Poly;
        else if (temp.Contains(BodyStyle.Paint)) return BodyStyle.Paint;
        else return BodyStyle.Pixel;
    }

    private WingStyle SetWing(PlorbData plorb)
    {
        List<WingStyle> temp = new List<WingStyle> { plorb.genes.wing1, plorb.genes.wing2 };

        if (temp.Contains(WingStyle.Poly)) return WingStyle.Poly;
        else if (temp.Contains(WingStyle.Paint)) return WingStyle.Paint;
        else return WingStyle.Pixel;
    }

    private EarStyle SetEar(PlorbData plorb)
    {
        List<EarStyle> temp = new List<EarStyle> { plorb.genes.ear1, plorb.genes.ear2 };

        if (temp.Contains(EarStyle.Poly)) return EarStyle.Poly;
        else if (temp.Contains(EarStyle.Paint)) return EarStyle.Paint;
        else return EarStyle.Pixel;
    }

    //eye style has a special component; it is actually completely random between the two genes
    private EyeStyle SetEye(PlorbData plorb)
    {
        if (Random.Range(0f, 1f) > .5f) return plorb.genes.eye1; else return plorb.genes.eye2;
    }

    private GameObject BlankPlorb() { return (GameObject)Instantiate(blankPlorbPrefab, new Vector3(0, 0, 0), Quaternion.identity); }
}


