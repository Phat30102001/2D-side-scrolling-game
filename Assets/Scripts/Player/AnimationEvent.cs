using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    private PlayerAttack playerAttack;

    private void Awake()
    {
        playerAttack = GameObject.Find("PlayerAttack").GetComponent<PlayerAttack>();
    }

    public void ActiveHitbox()
    {
        playerAttack.CheckHitbox();
    }
}
