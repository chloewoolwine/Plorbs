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
            plorb.gameObject.transform.position = new Vector3(0, 0);
            plorb.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
