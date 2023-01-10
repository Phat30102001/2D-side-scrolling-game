using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour
{
    public GameObject hitBox;
    private bool attackFinished;

    private void Start()
    {
        DisableHitBox();
        attackFinished = true;
    }
    public void AtiveHitBox()
    {
        hitBox.SetActive(true);
    }

    public void DisableHitBox()
    {
        hitBox.SetActive(false);
    }
    public void AttackAvailable()
    {
        attackFinished = true;
    }
    public void AttackUnavailable()
    {
        attackFinished = false;
    }
    public bool CheckAttackAvailabled()
    {
        // if method return true, enemy can attack
        return attackFinished;
    }

}
