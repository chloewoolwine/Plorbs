using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlorbInteractions : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public Collider2D mycollider;

    public PlorbData myData;

    private Vector2 previousPos;
    private bool isMouseDown;
    public Vector2 direction;

    private PlorbAnimator anim;
    
    [Tooltip("Optional limit on how fast the object can follow")]
    public float maxSpeed = float.PositiveInfinity;

    Rigidbody2D _body;
    BoxCollider2D _collider;

    delegate YieldInstruction dragMethod(Vector2 destination);

    // Start a drag using the selected method when clicked.
    void OnMouseDown()
    {
        dragMethod method =  Velocity;

        // Start a function that will run each frame/physics step
        // to update our dragged position until the button is released.

        isMouseDown = true; //because we're in the on mouse down function

        StartCoroutine(Drag());
        PlorbDataScreen.INSTANCE.ShowPlorb(myData);
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1))
        {
            //do stuff here
            RightClickMenu.INSTANCE.MoveToPlorb(myData);
        }
    }

    //use the method from DragTest!!
    //except we are turning gravity off, and whenever the drag completes do a small "plop" animation before constraining the y position
    void OnMouseDrag()
    {
        if (!isMouseDown)
            return;
    }

    private void OnMouseUp()
    {
        isMouseDown = false; //drag is complete, mouse btn is no longer down

    }

    //IDEA: USE z axis as a sort of "height" container. drag means z = 1, whenever END drag the dude will start falling until 1. z = 0 or 2. he has reached an illegal y position (cant fling them off)

    // Update the dragged position as long as the mouse button is held.
    IEnumerator Drag()
    {
        anim.SetDragSortedOrder();

      //  _body.transform.position = new Vector3(_body.transform.position.x, _body.transform.position.y, 1);
        // Stash our current offset from the cursor, 
        // so we can preserve it through the move.
        var offset = transform.InverseTransformPoint(ComputeCursorPosition());

        while (Input.GetMouseButton(0))
        {
            // Keep the object from accumulating velocity while dragging.
            _body.velocity = Vector2.zero;
            _body.angularVelocity = 0f;

            // Calculate desired drag position.
            var cursor = ComputeCursorPosition();
            var destination = cursor - transform.TransformVector(offset);

            var travel = Vector2.ClampMagnitude(
                destination - transform.position,
                maxSpeed * Time.deltaTime);

            // Let our chosen drag method choose how to get us there.
            yield return Velocity(_body.position + travel);
        }

        height = basePickupHeight*_body.velocity.magnitude;
        yield return StartCoroutine(Fall());
    }

    // Effectively the same results as MovePosition.
    YieldInstruction Velocity(Vector2 destination)
    {
        var velocity = (destination - _body.position) / Time.deltaTime;
        _body.velocity = velocity;
        return new WaitForFixedUpdate();
    }

    
    public float height;
    public float basePickupHeight;  
    IEnumerator Fall()
    {
        while(height > 0)
        {
            _body.velocity += new Vector2(0, -.8f);
          //  if(_body.velocity.sqrMagnitude < 1000)
                height = height-_body.velocity.sqrMagnitude;
            yield return new WaitForFixedUpdate();
        }

        _body.velocity *= new Vector2(1f, 0f);
    }

    // Initialize component dependencies.
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        anim = GetComponent<PlorbAnimator>();
    }

    // Utility functions to compute dragged position.
    float GetDepthOffset(Transform relativeTo)
    {
        Vector3 offset = transform.position - relativeTo.position;
        return Vector3.Dot(offset, relativeTo.forward);
    }

    Vector3 ComputeCursorPosition()
    {
        var camera = Camera.main;
        var screenPosition = Input.mousePosition;
        screenPosition.z = GetDepthOffset(camera.transform);
        var worldPosition = camera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
