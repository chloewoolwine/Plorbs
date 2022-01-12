using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlorbAnimator : MonoBehaviour
{
    public Sprite paintBody;
    public Sprite polyBody;
    public Sprite pixelBody;

    public Sprite paintEar;
    public Sprite polyEar;
    public Sprite pixelEar;

    public Sprite paintWing;
    public Sprite polyWing;
    public Sprite pixelWing;

    public Sprite paintEye;
    public Sprite polyEye;
    public Sprite pixelEye;

    public Sprite egg;

    public SpriteRenderer bodyRenderer;
    public SpriteRenderer wingRenderer;
    public SpriteRenderer earRenderer;
    public SpriteRenderer eyeRenderer;

    public List<SpriteRenderer> myRenders;

    public Animator bodyAnimator;
    public Animator wingAnimator;
    public Animator earAnimator;
    public Animator eyeAnimator;

    public List<Animator> animators;

    public PlorbData theData;

    private bool isMouseDown = false;

    private void Awake()
    {
        myRenders.Add(bodyRenderer);
        myRenders.Add(wingRenderer);
        myRenders.Add(earRenderer);
        myRenders.Add(eyeRenderer);
    }

    private void Update()
    {
        if (!isMouseDown)
        {
            foreach (SpriteRenderer x in myRenders)
                x.sortingOrder = (int)(bodyRenderer.transform.position.y * -100);
            bodyRenderer.sortingOrder = bodyRenderer.sortingOrder + 1; //c:
            eyeRenderer.sortingOrder = eyeRenderer.sortingOrder + 2;
        }
    }

    //attatch the hue changing to the onhatch function once it is created
    public void ResetHue()
    {
        switch (theData.body)
        {
            case BodyStyle.Pixel:
                bodyRenderer.sprite = pixelBody;
                break;
            case BodyStyle.Poly:
                bodyRenderer.sprite = polyBody;
                break;
            case BodyStyle.Paint:
                bodyRenderer.sprite = paintBody;
                break;
        }

        switch (theData.wing)
        {
            case WingStyle.Pixel:
                wingRenderer.sprite = pixelWing;
                break;
            case WingStyle.Poly:
                wingRenderer.sprite = polyWing;
                break;
            case WingStyle.Paint:
                wingRenderer.sprite = paintWing;
                break;
        }

        switch (theData.ear)
        {
            case EarStyle.Pixel:
                earRenderer.sprite = pixelEar;
                break;
            case EarStyle.Poly:
                earRenderer.sprite = polyEar;
                break;
            case EarStyle.Paint:
                earRenderer.sprite = paintEar;
                break;
        }

        if (theData.Age < 10)
        {
            bodyRenderer.sprite = egg;
        }

        theData.hue.a = 1f;
        bodyRenderer.color = theData.hue;
        earRenderer.color = theData.hue;
        wingRenderer.color = theData.hue;
    }

    public void SetDragSortedOrder()
    {
        foreach (SpriteRenderer x in myRenders)
            x.sortingOrder = 1000;

        switch (theData.body)
        {
            case BodyStyle.Pixel:
                bodyAnimator.Play("CartoonBodySquirm");
                break;
            case BodyStyle.Poly:
                bodyAnimator.Play("CartoonBodySquirm");
                break;
            case BodyStyle.Paint:
                bodyAnimator.Play("CartoonBodySquirm");
                break;
        }

        switch (theData.wing)
        {
            case WingStyle.Pixel:
                wingAnimator.Play("CartoonWingSquirm");
                break;
            case WingStyle.Poly:
                wingAnimator.Play("CartoonWingSquirm");
                break;
            case WingStyle.Paint:
                wingAnimator.Play("CartoonWingSquirm");
                break;
        }

        switch (theData.ear)
        {
            case EarStyle.Pixel:
                earAnimator.Play("CartoonEarSquirm");
                break;
            case EarStyle.Poly:
                earAnimator.Play("CartoonEarSquirm");
                break;
            case EarStyle.Paint:
                earAnimator.Play("CartoonEarSquirm");
                break;
        }

        eyeAnimator.Play("CartoonEyeSquirm");
    }

    public void Hatch()
    {
        ResetHue();
    }

    void OnMouseDown()
    {
        isMouseDown = true; //because we're in the on mouse down function=
    }

    void OnMouseDrag()
    {
        if (!isMouseDown)
            return;
    }

    private void OnMouseUp()
    {
        isMouseDown = false; //drag is complete, mouse btn is no longer down
        Idle();
    }

    public void Idle()
    {
        switch (theData.body)
        {
            case BodyStyle.Pixel:
                bodyAnimator.Play("CartoonBodyIdle");
                break;
            case BodyStyle.Poly:
                bodyAnimator.Play("CartoonBodyIdle");
                break;
            case BodyStyle.Paint:
                bodyAnimator.Play("CartoonBodyIdle");
                break;
        }

        switch (theData.wing)
        {
            case WingStyle.Pixel:
                wingAnimator.Play("CartoonWingIdle");
                break;
            case WingStyle.Poly:
                wingAnimator.Play("CartoonWingIdle");
                break;
            case WingStyle.Paint:
                wingAnimator.Play("CartoonWingIdle");
                break;
        }

        switch (theData.ear)
        {
            case EarStyle.Pixel:
                earAnimator.Play("CartoonEarsIdle");
                break;
            case EarStyle.Poly:
                earAnimator.Play("CartoonEarsIdle");
                break;
            case EarStyle.Paint:
                earAnimator.Play("CartoonEarsIdle");
                break;
        }

        eyeAnimator.Play("CartoonEyesIdle");
    }


    //put plorb death anim here
    //TODO: replace cartoon with other bodytypes, add eyes
    public void onDeath()
    {
        switch (theData.body)
        {
            case BodyStyle.Pixel:
                bodyAnimator.Play("CartoonExplosionBody");
                break;
            case BodyStyle.Poly:
                bodyAnimator.Play("CartoonExplosionBody");
                break;
            case BodyStyle.Paint:
                bodyAnimator.Play("CartoonExplosionBody");  
                break;
        }

        switch (theData.wing)
        {
            case WingStyle.Pixel:
                wingAnimator.Play("CartoonExplosionWing");
                break;
            case WingStyle.Poly:
                wingAnimator.Play("CartoonExplosionWing");
                break;
            case WingStyle.Paint:
                wingAnimator.Play("CartoonExplosionWing");
                break;
        }

        switch (theData.ear)
        {
            case EarStyle.Pixel:
                earAnimator.Play("CartoonExplosionEar");
                break;
            case EarStyle.Poly:
                earAnimator.Play("CartoonExplosionEar");
                break;
            case EarStyle.Paint:
                earAnimator.Play("CartoonExplosionEar");
                break;
        }

        print("plorb has died.");
        //no eye epxlosion yet
    }
}
