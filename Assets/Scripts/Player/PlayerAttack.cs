using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public bool isAttacking = false;

    public GameObject attackArea;

    public Transform attackHitboxArea;
    public LayerMask damagealbeObject;
    public float attackRadius;

    public static PlayerAttack instance;

    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        animator = GameObject.Find("PlayerAnimator").GetComponent<Animator>();
        //attackArea.SetActive(false);
    }

    public void Attack(InputAction.CallbackContext context)
    {

        if (context.performed && !isAttacking)
        {
            //Debug.Log("0");
            isAttacking = true;
            
        }
    }

    //public void AtiveHitbox(bool isAttacking)
    //{
    //    attackArea.SetActive(isAttacking);
    //}

    public void CheckHitbox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackHitboxArea.position, attackRadius, damagealbeObject);

        foreach (Collider2D collider in detectedObjects)
        {
            Debug.Log("Damaged");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackHitboxArea.position, attackRadius);
    }
}
