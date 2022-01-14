using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Holds data that changes between plorbs- i.e. genetic data and current need values
public class PlorbData : MonoBehaviour
{
    public BodyStyle body;
    public EarStyle ear;
    public WingStyle wing;

    //monetary value of a plorb.
    public int value;

    //an age of 10 means the plorb hatches
    private int age;

    public Color hue;
    public string givenName;
    public string title;
    
    //juice capacity is the only dynamic value that has a capacity other than 100. after total juice capacity is reached the plorb will slowly loose happiness before Exploding.
    public int totalJuiceCapacity;

    //all in per seconds
    public float hungerDecayRate;
    public float happinessDecayRate;
    public float juiceIncreaseRate;

    public DeathState deathState;
    public int deathtimer; //when this gets to 0, your plorb fucking dies.

    public PlorbGenes genes;

    private float happiness;
    private float hunger;
    private float currentJuice;

    public float Happiness
    {
        get { return happiness; }
        set
        {
            happiness = value;
            if (value <= 0)
            {
                BeginDying(DeathState.Happiness);
            }
            else deathState = DeathState.Healthy;
        }
    }
    
    public float Hunger
    {
        get { return hunger; }
        set
        {
            hunger = value;
            //Debug.Log("Plorb hunger change " + hunger);
            if (value <= 0)
            {
                BeginDying(DeathState.Hunger);
            }
            else deathState = DeathState.Healthy;
        }
    }

    public float CurrentJuice
    {
        get { return currentJuice; }
        set
        {
            currentJuice = value;
            if (value > totalJuiceCapacity)
            {
            //    BeginDying(DeathState.Juice);
            }
            else deathState = DeathState.Healthy;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            age = value;
            if (age == 10) GetComponent<PlorbAnimator>().Hatch();
        }
    }

    public void Feed(int num)
    {
        Hunger = hunger + num;
    }

    public void Pet(int num)
    {
        Happiness = happiness + num;
    }

    public float Juice()
    {
        float temp = currentJuice;
        CurrentJuice = 0;
        return temp;
    }

    //TODO: Determine storage method for different traits and store them in here

    private void Start()
    {
        deathtimer = 30;
        Hunger = 30;
        CurrentJuice = 10;
        Happiness = 30;
        StartCoroutine(DecayStats());
        //print("your little buddy is alive");
    }
    
    private void BeginDying(DeathState methodOfDye)
    {
        deathState = methodOfDye;
        deathtimer = 30;
        StartCoroutine(DeathCountdown());
    }

    //a better perfomance version would be to have one single class
    //that manages the decay for all currently living plorbs, but this 
    //will do for now.
    IEnumerator DecayStats()
    {
        //print("your little buddy is slowly dying");
        for (; ; )
        {
            Hunger -= hungerDecayRate;
            Happiness -= happinessDecayRate;
            CurrentJuice += juiceIncreaseRate;
            Age += 1;
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator DeathCountdown()
    {
        while(deathState != DeathState.Healthy)
        {
            Debug.Log("plorb is dying.");
            deathtimer--;

            if (deathState == DeathState.Juice)
                happiness -= 1;

            if(deathtimer <= 0)
            {
                PlorbDefiner.INSTANCE.DestroyPlorb(this);
            }
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

public enum DeathState
{
    Healthy,
    Happiness,
    Hunger,
    Juice
}

