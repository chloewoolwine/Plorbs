using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlorbDataScreen : MonoBehaviour
{
    public static PlorbDataScreen INSTANCE;
    
    public PlorbData currentPlorb;

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

    public Slider hunger;
    public Slider happiness;
    public Slider juice;

    private void Awake()
    {
        INSTANCE = this;
    }

    public void ShowPlorb(PlorbData plorb)
    {
        currentPlorb = plorb;
        SetBody();
        SetWing();
        SetEar();
        SetEye();

        hunger.value = plorb.Hunger / 100;
        happiness.value = plorb.Happiness / 100;
        juice.value = plorb.CurrentJuice / plorb.totalJuiceCapacity;
    }

    private void SetBody()
    {
        switch (currentPlorb.body)
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

        body.color = currentPlorb.hue;
    }

    private void SetWing()
    {
        switch (currentPlorb.wing)
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
        wing.color = currentPlorb.hue;
    }

    private void SetEar()
    {
        switch (currentPlorb.ear)
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
        ear.color = currentPlorb.hue;
    }

    private void SetEye()
    {
        switch (currentPlorb.body)
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
