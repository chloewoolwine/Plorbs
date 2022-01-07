using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Holds data that changes between plorbs- i.e. genetic data and current need values
public class PlorbData : MonoBehaviour
{
    public BodyStyle body;
    public EarStyle ear;
    public WingStyle wing;

    public Color hue;
    public string givenName;
    public string title;

    public float happiness;
    public float hunger;
    public float currentJuice;
    //juice capacity is the only dynamic value that has a capacity other than 100. after total juice capacity is reached the plorb will slowly loose happiness before Exploding.
    public int totalJuiceCapacity;
    public int juiceExplosionThreshold;

    //all in per seconds
    public float hungerDecayRate;
    public float happinessDecayRate;
    public float juiceIncreaseRate;

    //monetary value of a plorb.
    public int value;

    public PlorbGenes genes;

    //TODO: Determine storage method for different traits and store them in here

    private void Start()
    {
        StartCoroutine(DecayStats());
        //print("your little buddy is alive");
    }

    //a better perfomance version would be to have one single class
    //that manages the decay for all currently living plorbs, but this 
    //will do for now.
    IEnumerator DecayStats()
    {
        //print("your little buddy is slowly dying");
        for (; ; )
        {
            hunger -= hungerDecayRate;
            happiness -= happinessDecayRate;
            currentJuice += juiceIncreaseRate;
            yield return new WaitForSeconds(1f);
        }
    }

}

[System.Serializable]
public class PlorbGenes
{
    public BodyStyle body1;
    public BodyStyle body2;

    public WingStyle wing1;
    public WingStyle wing2;

    public EarStyle ear1;
    public EarStyle ear2;

    public PlorbGenes(BodyStyle b1, BodyStyle b2, WingStyle w1, WingStyle w2, EarStyle e1, EarStyle e2)
    {
        body1 = b1;
        body2 = b2;
        wing1 = w1;
        wing2 = w2;
        ear1 = e1;
        ear2 = e2;
    }
}

public enum BodyStyle
{
    Paint,
    Poly,
    Pixel
}

public enum EarStyle
{
    Paint,
    Poly,
    Pixel
}

public enum WingStyle
{
    Paint,
    Poly,
    Pixel
}

