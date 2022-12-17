using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public bool isAttacking = false;

    public static PlayerAttack instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        animator = GameObject.Find("PlayerAnimator").GetComponent<Animator>();
    }

    public void HandleAttack(InputAction.CallbackContext context)
    {

        if (context.performed && !isAttacking)
        {
            Debug.Log("0");
            isAttacking = true;
        }
    }
}
