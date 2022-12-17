using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBehaviour1 : StateMachineBehaviour
{
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerAttack.instance.isAttacking)
        {
            PlayerAttack.instance.animator.Play("PlayerAttack2");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerAttack.instance.isAttacking = false;
    }
}
