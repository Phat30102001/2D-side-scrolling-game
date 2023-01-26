using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class DisableHole : Action
{

    public override void OnStart()
    {
        ProjectileManager.instance.projectileHole.SetActive(false);
    }
}
