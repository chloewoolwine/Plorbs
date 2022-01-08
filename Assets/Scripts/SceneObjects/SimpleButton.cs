using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleButton : MonoBehaviour
{
    public event UnityAction mousedown;

    private void OnMouseDown()
    {
        mousedown.Invoke();
    }
}
