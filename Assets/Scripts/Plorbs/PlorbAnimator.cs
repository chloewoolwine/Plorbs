using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlorbAnimator : MonoBehaviour
{
    public Sprite pixelBody;
    public Sprite paintBody;
    public Sprite polyBody;

    public SpriteRenderer mySprite;
    public PlorbData theData;

    private bool isMouseDown;

    private void Update()
    {
        if (!isMouseDown)
            mySprite.sortingOrder = (int)(mySprite.transform.position.y * -100);
    }

    //attatch the hue changing to the onhatch function once it is created
    public void ResetHue()
    {
        switch (theData.body)
        {
            case BodyStyle.Pixel:
                mySprite.sprite = pixelBody;
                break;
            case BodyStyle.Poly:
                mySprite.sprite = polyBody;
                break;
            case BodyStyle.Paint:
                mySprite.sprite = paintBody;
                break;
        }
        mySprite.color = theData.hue;
    }

    public void SetDragSortedOrder()
    {
        mySprite.sortingOrder = 1000;
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
    }
}
