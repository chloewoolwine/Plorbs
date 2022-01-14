using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlorbContainer : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlorbData plorb = collision.GetComponent<PlorbData>();

        if (plorb)
        {
            Rigidbody2D body = plorb.GetComponent<Rigidbody2D>();
            Vector2 opposite = -body.velocity;
            body.velocity = opposite;
        }
    }
}
