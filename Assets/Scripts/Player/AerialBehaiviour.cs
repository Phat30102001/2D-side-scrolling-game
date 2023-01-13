using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialBehaiviour : StateMachineBehaviour
{
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerAttack.instance.isAirAttacking)
        {
            Debug.Log("HIting");
            PlayerAttack.instance.animator.Play("PlayerAttack1");
        }
    }

}
