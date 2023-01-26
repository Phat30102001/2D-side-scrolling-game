using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class ProjectileFromHole : Action
{
    [SerializeField] private GameObject minion;
    public override void OnStart()
    {
        ProjectileManager.instance.projectileHole.SetActive(true);
        MinionSpawner();
    }

    public void MinionSpawner()
    {
        GameObject m=Object.Instantiate(minion);
    }
}
