using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class HealthCheck : Action
{
    public UnitStatReceiver stat;

    [SerializeField] private SharedInt hp;

    public SharedInt Hp { get => hp; set => hp = value; }

    public override void OnStart()
    {
        stat=gameObject.GetComponentInChildren<UnitStatReceiver>();
    }
    public override TaskStatus OnUpdate()
    {
        Hp = stat.CurrentHp;

        return TaskStatus.Success;
    }
}
