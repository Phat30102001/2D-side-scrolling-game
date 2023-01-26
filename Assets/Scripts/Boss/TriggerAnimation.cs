using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class TriggerAnimation : Action
{
    public string animationName;
    public Animator animator;

    public override void OnStart()
    {
        AnimationTrigger(animationName);
    }

    public void AnimationTrigger(string animationName)
    {
        animator.SetTrigger(animationName); 
    }
}
