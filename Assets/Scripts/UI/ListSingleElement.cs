using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListSingleElement : MonoBehaviour
{

    public Image body;
    public Image wing;
    public Image eye;
    public Image ear;

    public Sprite paintB;
    public Sprite paintW;
    public Sprite paintEy;
    public Sprite paintEa;

    public Sprite pixelB;
    public Sprite pixelW;
    public Sprite pixelEy;
    public Sprite pixelEa;

    public Sprite polyB;
    public Sprite polyW;
    public Sprite polyEy;
    public Sprite polyEa;

    public Button button;

    public void ShowPlorb(PlorbSaveData plorb)
    {
        SetBody(plorb);
        SetWing(plorb);
        SetEar(plorb);
        SetEye(plorb);
    }

    private void SetBody(PlorbSaveData plorb)
    {
        switch (plorb.body)
        {
            case BodyStyle.Paint:
                body.sprite = paintB;
                break;
            case BodyStyle.Pixel:
                body.sprite = pixelB;
                break;
            case BodyStyle.Poly:
                body.sprite = polyB;
                break;
        }

        body.color = new Color(plorb.r, plorb.g, plorb.b, 1f);
    }

    private void SetWing(PlorbSaveData plorb)
    {
        switch (plorb.wing)
        {
            case WingStyle.Paint:
                wing.sprite = paintW;
                break;
            case WingStyle.Pixel:
                wing.sprite = pixelW;
                break;
            case WingStyle.Poly:
                wing.sprite = polyW;
                break;
        }
        wing.color = new Color(plorb.r, plorb.g, plorb.b, 1f);
    }

    private void SetEar(PlorbSaveData plorb)
    {
        switch (plorb.ear)
        {
            case EarStyle.Paint:
                ear.sprite = paintEa;
                break;
            case EarStyle.Pixel:
                ear.sprite = pixelEa;
                break;
            case EarStyle.Poly:
                ear.sprite = polyEa;
                break;
        }
        ear.color = new Color(plorb.r, plorb.g, plorb.b, 1f);
    }

    private void SetEye(PlorbSaveData plorb)
    {
        switch (plorb.body)
        {
            case BodyStyle.Paint:
                eye.sprite = paintEy;
                break;
            case BodyStyle.Pixel:
                eye.sprite = pixelEy;
                break;
            case BodyStyle.Poly:
                eye.sprite = polyEy;
                break;
        }
    }
}
