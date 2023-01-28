using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class FaceSide : Action
{
    private Transform player;

    public override void OnStart()
    {
        player = GameObject.Find("Player").transform;
    }

    public override TaskStatus OnUpdate()
    {
        if (Facingside() > 0)
        {
            transform.localScale = new Vector2(transform.localScale.x*-1,1) ;
        }

        return TaskStatus.Success;
    }

    public float Facingside()
    {
        float side= (transform.position.x - player.position.x)*transform.localScale.x;
        return side;
    }
}
