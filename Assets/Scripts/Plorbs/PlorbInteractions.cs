using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlorbInteractions : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public Collider2D mycollider;

    private Vector2 previousPos;
    private bool isMouseDown;
    public Vector2 direction;
    

    void OnMouseDown()
    {
        isMouseDown = true; //because we're in the on mouse down function=
    }

    //use the method from DragTest!!
    //except we are turning gravity off, and whenever the drag completes do a small "plop" animation before constraining the y position
    void OnMouseDrag()
    {
        if (!isMouseDown)
            return;
       
    //    Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

     //   myrigidbody.MovePosition(mousePos);

    //    direction = (new Vector3(mousePos.x, mousePos.y, 0) - transform.position).normalized;
    //    myrigidbody.AddForce(direction * Time.deltaTime * 10);


    }

    private void OnMouseUp()
    {
     //   isMouseDown = false; //drag is complete, mouse btn is no longer down

    }
}
