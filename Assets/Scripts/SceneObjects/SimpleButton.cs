using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleButton : MonoBehaviour
{
    public event UnityAction mousedown;
    public GameObject spriteToTween;
    private Vector3 original;
    public Color colorToTween;
    public Vector3 hoverSize = new Vector3(1.2f, 1.2f, 1f);

    private void OnMouseDown()
    {
        print("clicked!");
        mousedown?.Invoke();
    }
    
    private void OnMouseEnter()
    {
        print("mouse over!");
        if (spriteToTween)
        {
            original = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            LeanTween.scale(spriteToTween, hoverSize, .2f);
            LeanTween.color(spriteToTween, colorToTween, .2f);
        }
    }

    private void OnMouseExit()
    {
        if (spriteToTween)
        {
            LeanTween.scale(spriteToTween, original, .2f);
            LeanTween.color(spriteToTween, Color.white, .2f);
        }
        
        print("mouse exited!");
    }
}
