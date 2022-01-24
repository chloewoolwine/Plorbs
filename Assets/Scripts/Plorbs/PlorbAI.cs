using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlorbAI : MonoBehaviour
{
    public Action currentAction;
    public PlorbAnimator anim;
    public Rigidbody2D body;
    public float movementspeed;
    public PlorbData mydata;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.gameObject.transform.position;
        if(pos.x < -20 || pos.y < -10 || pos.x > 20 || pos.y > 10)
        {
            PlorbDefiner.INSTANCE.DestroyPlorb(GetComponent<PlorbData>());
        }

        if (mydata.Age < 10)
        {
            return;
        }
        if (currentAction == Action.JackShit && body.velocity == Vector2.zero)
        {
            float chance = Random.Range(0f, 1f);

            if(chance < .0005) //3 percent chance every second for them to do something, assuming 60 frames a second
            {
                Action newAction = (Action)Random.Range(1, 6);

                switch (newAction)
                {
                    case Action.WalkUp:
                        body.velocity += new Vector2(0, movementspeed);
                        break;
                    case Action.WalkDown:
                        body.velocity += new Vector2(0, -movementspeed);
                        break;
                    case Action.WalkRight:
                        body.velocity += new Vector2(movementspeed, 0);
                        break;
                    case Action.WalkLeft:
                        body.velocity += new Vector2(-movementspeed, 0);
                        break;
                    case Action.Jump:
                        break;
                    case Action.Squanch: //idk what squanching is tbh
                        break;
                }
                

            }
        }
    }
    

    public enum Action
    {
        JackShit,
        WalkUp,
        WalkDown,
        WalkRight,
        WalkLeft,
        Jump,
        Squanch
    }
}
