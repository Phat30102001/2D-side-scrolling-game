using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class DisableProjectile : Action
{
    public override void OnStart()
    {
        foreach (GameObject p in ProjectileManager.instance.projectilePool)
        {
            p.SetActive(false);
        }
    }
}
