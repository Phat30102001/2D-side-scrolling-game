using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public bool isAttacking = false;
    public bool isAirAttacking = false;

    public GameObject attackArea;

    public Transform attackHitboxArea;
    public LayerMask damagealbeObject;
    public float attackRadius;

    private UnitStatReceiver unit;

    public static PlayerAttack instance;

    private void Awake()
    {
        instance = this;

        unit = GameObject.Find("PlayerStat").GetComponent<UnitStatReceiver>();
    }
    
    private void Start()
    {
        animator = GameObject.Find("PlayerAnimator").GetComponent<Animator>();
        //attackArea.SetActive(false);
    }

    public void Attacking()
    {
        isAttacking = true;
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
            if (collider.tag != "Enemy") return;
            UnitStatReceiver enemyStat = collider.transform.GetChild(2).GetComponent<UnitStatReceiver>();

            enemyStat.TakeDamage(unit.Damage);
            if (enemyStat.CurrentHp <= 0)
                unit.TransferMoney(enemyStat.Money); 
            
            collider.transform.GetChild(0).GetComponent<EnemyDamaged>().Flash();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackHitboxArea.position, attackRadius);
    }
}
