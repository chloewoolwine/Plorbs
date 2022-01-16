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
    public Rigidbody2D myRigid;

    public bool InControl;

    public bool isMouseDown;

    private void Awake()
    {
        isMouseDown = false;
        InControl = true;
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

        //right postive, left negative
        //up positive, down negative.
        //if we are moving
        if (!isMouseDown && InControl) //change to check of plorb interacitons
        {
            if (myRigid.velocity.magnitude > 1)
            {
                if (myRigid.velocity.y == 0) //if we are rolling
                {
                    if (myRigid.velocity.x > 0)
                    {
                        RollRight();
                    }
                    else
                    {
                        RollLeft();
                    }
                    // print("rolling " + myRigid.velocity.x);
                }
                else //we are in the air. 
                {
                    if(myRigid.velocity.y < 0)
                    {
                        if (myRigid.velocity.x > 10)
                        {
                            FlingRight();
                        }
                        else if (myRigid.velocity.x < 10)
                        {
                            FlingLeft();
                        }
                        else
                        {
                            RollForwards();
                        }
                    } else //we are heading up
                    {
                        if(myRigid.velocity.y > 10)
                        {
                            FlingUp();
                        } else
                        {
                            RollBackwards();
                        }
                    }
                }
            }
            else
            {
                Idle();
            }
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
        Idle();
    }

    public void SetDragSortedOrder()
    {
        foreach (SpriteRenderer x in myRenders)
            x.sortingOrder = 1000;

        switch (theData.body)
        {
            case BodyStyle.Pixel:
                bodyAnimator.Play("PixelBodySquirm");
                break;
            case BodyStyle.Poly:
                bodyAnimator.Play("PolyBodySquirm");
                break;
            case BodyStyle.Paint:
                bodyAnimator.Play("CartoonBodySquirm");
                break;
        }

        switch (theData.wing)
        {
            case WingStyle.Pixel:
                wingAnimator.Play("PixelWingSquirm");
                break;
            case WingStyle.Poly:
                wingAnimator.Play("PolyWingSquirm");
                break;
            case WingStyle.Paint:
                wingAnimator.Play("CartWingSquirm");
                break;
        }

        switch (theData.ear)
        {
            case EarStyle.Pixel:
                earAnimator.Play("PixelEarSquirm");
                break;
            case EarStyle.Poly:
                earAnimator.Play("PolyEarSquirm");
                break;
            case EarStyle.Paint:
                earAnimator.Play("CartEarSquirm");
                break;
        }

        switch (theData.eye)
        {
            case EyeStyle.Pixel:
                eyeAnimator.Play("PixelEyeSquirm");
                break;
            case EyeStyle.Poly:
                eyeAnimator.Play("PolyEyeSquirm");
                break;
            case EyeStyle.Paint:
                eyeAnimator.Play("CartEyeSquirm");
                break;
        }
        
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
                bodyAnimator.Play("PixelBodyIdle");
                break;
            case BodyStyle.Poly:
                bodyAnimator.Play("PolyBIdle");
                break;
            case BodyStyle.Paint:
                bodyAnimator.Play("CartoonBodyIdle");
                break;
        }

        switch (theData.wing)
        {
            case WingStyle.Pixel:
                wingAnimator.Play("PixelWingIdle");
                break;
            case WingStyle.Poly:
                wingAnimator.Play("PolyWingIdle");
                break;
            case WingStyle.Paint:
                wingAnimator.Play("CartoonWingIdle");
                break;
        }

        switch (theData.ear)
        {
            case EarStyle.Pixel:
                earAnimator.Play("PixelEarIdle");
                break;
            case EarStyle.Poly:
                earAnimator.Play("PolyEarIdle");
                break;
            case EarStyle.Paint:
                earAnimator.Play("CartoonEarsIdle");
                break;
        }

        switch (theData.eye)
        {
            case EyeStyle.Pixel:
                eyeAnimator.Play("PixelEyeIdle");
                break;
            case EyeStyle.Poly:
                eyeAnimator.Play("PolyEyeIdle");
                break;
            case EyeStyle.Paint:
                eyeAnimator.Play("CartoonEyesIdle");
                break;
        }
        
    }


    //put plorb death anim here
    //TODO: replace cartoon with other bodytypes, add eyes
    public void onDeath()
    {
        InControl = false;
        switch (theData.body)
        {
            case BodyStyle.Pixel:
                bodyAnimator.Play("PixelBodyExplode");
                break;
            case BodyStyle.Poly:
                bodyAnimator.Play("PolyBodyExplode");
                break;
            case BodyStyle.Paint:
                bodyAnimator.Play("CartoonExplosionBody");  
                break;
        }

        switch (theData.wing)
        {
            case WingStyle.Pixel:
                wingAnimator.Play("PixelWingExplode");
                break;
            case WingStyle.Poly:
                wingAnimator.Play("PolyWingExplode");
                break;
            case WingStyle.Paint:
                wingAnimator.Play("CartoonExplosionWing");
                break;
        }

        switch (theData.ear)
        {
            case EarStyle.Pixel:
                earAnimator.Play("PixelEarExplode");
                break;
            case EarStyle.Poly:
                earAnimator.Play("PolyEarExplode");
                break;
            case EarStyle.Paint:
                earAnimator.Play("CartoonExplosionEar");
                break;
        }

        switch (theData.eye)
        {
            case EyeStyle.Pixel:
                eyeAnimator.Play("PixelEyesExplode");
                break;
            case EyeStyle.Poly:
                eyeAnimator.Play("PolyEyeExplode");
                break;
            case EyeStyle.Paint:
                eyeAnimator.Play("CartoonExplosionEyes");
                break;
        }

        print("plorb has died.");
    }
    
    public void FlingRight()
    {
        switch (theData.body)
        {
            case BodyStyle.Pixel:
                bodyAnimator.Play("PixelBodyRFling");
                break;
            case BodyStyle.Poly:
                bodyAnimator.Play("PolyBodyRFling");
                break;
            case BodyStyle.Paint:
                bodyAnimator.Play("CartoonBodyRFling");
                break;
        }

        switch (theData.wing)
        {
            case WingStyle.Pixel:
                wingAnimator.Play("PixelWingRFling");
                break;
            case WingStyle.Poly:
                wingAnimator.Play("PolyWingRFling");
                break;
            case WingStyle.Paint:
                wingAnimator.Play("CartoonWingRFling");
                break;
        }

        switch (theData.ear)
        {
            case EarStyle.Pixel:
                earAnimator.Play("PixelEarRFling");
                break;
            case EarStyle.Poly:
                earAnimator.Play("PolyEarRFling");
                break;
            case EarStyle.Paint:
                earAnimator.Play("CartoonEarRFling");
                break;
        }

        switch (theData.eye)
        {
            case EyeStyle.Pixel:
                eyeAnimator.Play("PixelEyeRFling");
                break;
            case EyeStyle.Poly:
                eyeAnimator.Play("PolyEyeRfling");
                break;
            case EyeStyle.Paint:
                eyeAnimator.Play("CartoonEyeRFling");
                break;
        }
        
    }

    public void FlingLeft()
    {
        switch (theData.body)
        {
            case BodyStyle.Pixel:
                bodyAnimator.Play("PixelBodyLFling");
                break;
            case BodyStyle.Poly:
                bodyAnimator.Play("PolyBodyLeftFling");
                break;
            case BodyStyle.Paint:
                bodyAnimator.Play("CartoonBodyLFling");
                break;
        }

        switch (theData.wing)
        {
            case WingStyle.Pixel:
                wingAnimator.Play("PixelWingLFling");
                break;
            case WingStyle.Poly:
                wingAnimator.Play("PolyWingLFling");
                break;
            case WingStyle.Paint:
                wingAnimator.Play("CartoonWingLFling");
                break;
        }

        switch (theData.ear)
        {
            case EarStyle.Pixel:
                earAnimator.Play("PixelEarLFling");
                break;
            case EarStyle.Poly:
                earAnimator.Play("PolyEarLFling");
                break;
            case EarStyle.Paint:
                earAnimator.Play("CartoonEarLFling");
                break;
        }

        switch (theData.eye)
        {
            case EyeStyle.Pixel:
                eyeAnimator.Play("PixelEyeLFling");
                break;
            case EyeStyle.Poly:
                eyeAnimator.Play("PolyEyeLFling");
                break;
            case EyeStyle.Paint:
                eyeAnimator.Play("CartoonEyeLFling");
                break;
        }
    }

    public void FlingUp()
    {
        switch (theData.body)
        {
            case BodyStyle.Pixel:
                bodyAnimator.Play("PixelBodyVFling");
                break;
            case BodyStyle.Poly:
                bodyAnimator.Play("PolyBodyVFling");
                break;
            case BodyStyle.Paint:
                bodyAnimator.Play("CartoonBodyVFling");
                break;
        }

        switch (theData.wing)
        {
            case WingStyle.Pixel:
                wingAnimator.Play("PixelWingVFling");
                break;
            case WingStyle.Poly:
                wingAnimator.Play("PolyWingVFling");
                break;
            case WingStyle.Paint:
                wingAnimator.Play("CartoonWingVFling");
                break;
        }

        switch (theData.ear)
        {
            case EarStyle.Pixel:
                earAnimator.Play("PixelEarVFling");
                break;
            case EarStyle.Poly:
                earAnimator.Play("PolyEarVFling");
                break;
            case EarStyle.Paint:
                earAnimator.Play("CartoonEarVFling");
                break;
        }

        switch (theData.eye)
        {
            case EyeStyle.Pixel:
                eyeAnimator.Play("PixelEyeVFling");
                break;
            case EyeStyle.Poly:
                eyeAnimator.Play("PolyEyeVFling");
                break;
            case EyeStyle.Paint:
                eyeAnimator.Play("CartoonEyeVFling");
                break;
        }

    }

    public void RollBackwards()
    {
        switch (theData.body)
        {
            case BodyStyle.Pixel:
                bodyAnimator.Play("PixelBodyBRoll");
                break;
            case BodyStyle.Poly:
                bodyAnimator.Play("PolyBodyBRoll");
                break;
            case BodyStyle.Paint:
                bodyAnimator.Play("CartoonBodyBRoll");
                break;
        }

        switch (theData.wing)
        {
            case WingStyle.Pixel:
                wingAnimator.Play("PixelWingBRoll");
                break;
            case WingStyle.Poly:
                wingAnimator.Play("PolyWingBRoll");
                break;
            case WingStyle.Paint:
                wingAnimator.Play("CartoonWingBRoll");
                break;
        }

        switch (theData.ear)
        {
            case EarStyle.Pixel:
                earAnimator.Play("PixelEarBRoll");
                break;
            case EarStyle.Poly:
                earAnimator.Play("PolyEarBRoll");
                break;
            case EarStyle.Paint:
                earAnimator.Play("CartoonEarBRoll");
                break;
        }

        switch (theData.eye)
        {
            case EyeStyle.Pixel:
                eyeAnimator.Play("PixelEyeBRoll");
                break;
            case EyeStyle.Poly:
                eyeAnimator.Play("PolyEyeBRoll");
                break;
            case EyeStyle.Paint:
                eyeAnimator.Play("CartoonEyeBRoll");
                break;
        }
        
    }

    public void RollForwards()
    {
        switch (theData.body)
        {
            case BodyStyle.Pixel:
                bodyAnimator.Play("PixelBodyFRoll");
                break;
            case BodyStyle.Poly:
                bodyAnimator.Play("PolyBodyFRoll");
                break;
            case BodyStyle.Paint:
                bodyAnimator.Play("CartoonBodyFRoll");
                break;
        }

        switch (theData.wing)
        {
            case WingStyle.Pixel:
                wingAnimator.Play("PixelWingFRoll");
                break;
            case WingStyle.Poly:
                wingAnimator.Play("PolyWingFRoll");
                break;
            case WingStyle.Paint:
                wingAnimator.Play("CartoonWingFRoll");
                break;
        }

        switch (theData.ear)
        {
            case EarStyle.Pixel:
                earAnimator.Play("PixelEarFRoll");
                break;
            case EarStyle.Poly:
                earAnimator.Play("PolyEarFRoll");
                break;
            case EarStyle.Paint:
                earAnimator.Play("CartoonEarFRoll");
                break;
        }

        eyeAnimator.Play("PixelEyeFRoll");
    }

    public void RollRight()
    {
        switch (theData.body)
        {
            case BodyStyle.Pixel:
                bodyAnimator.Play("PixelBodyRRoll");
                break;
            case BodyStyle.Poly:
                bodyAnimator.Play("PolyBodyRRoll");
                break;
            case BodyStyle.Paint:
                bodyAnimator.Play("CartoonBodyRRoll");
                break;
        }

        switch (theData.wing)
        {
            case WingStyle.Pixel:
                wingAnimator.Play("PixelWingRRoll");
                break;
            case WingStyle.Poly:
                wingAnimator.Play("PolyWingRRoll");
                break;
            case WingStyle.Paint:
                wingAnimator.Play("CartoonWingRRoll");
                break;
        }

        switch (theData.ear)
        {
            case EarStyle.Pixel:
                earAnimator.Play("PixelEarRRoll");
                break;
            case EarStyle.Poly:
                earAnimator.Play("PolyEarRRoll");
                break;
            case EarStyle.Paint:
                earAnimator.Play("CartoonEarRRoll");
                break;
        }

        eyeAnimator.Play("PixelEyeRRoll");
    }

    public void RollLeft()
    {
        switch (theData.body)
        {
            case BodyStyle.Pixel:
                bodyAnimator.Play("PixelBodyLRoll");
                break;
            case BodyStyle.Poly:
                bodyAnimator.Play("PolyBodyLRoll");
                break;
            case BodyStyle.Paint:
                bodyAnimator.Play("CartoonBodyLRoll");
                break;
        }

        switch (theData.wing)
        {
            case WingStyle.Pixel:
                wingAnimator.Play("PixelWingLRoll");
                break;
            case WingStyle.Poly:
                wingAnimator.Play("PolyWingLRoll");
                break;
            case WingStyle.Paint:
                wingAnimator.Play("CartoonWingLRoll");
                break;
        }

        switch (theData.ear)
        {
            case EarStyle.Pixel:
                earAnimator.Play("PixelEarLRoll");
                break;
            case EarStyle.Poly:
                earAnimator.Play("PolyEarLRoll");
                break;
            case EarStyle.Paint:
                earAnimator.Play("CartoonEarLRoll");
                break;
        }
        
        eyeAnimator.Play("PixelEyeLRoll");
    }
}
