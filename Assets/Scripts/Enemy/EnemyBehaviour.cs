using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform raycast;
    public LayerMask raycastMask;
    public float raycastLenght;
    public float attackDistance; //minimum distance for attack
    public float movespeed;
    public float timer; // time cooldown for the attack

    private RaycastHit2D hit;
    private GameObject target;
    private Animator animator;
    private float distance; // store distance between player and enemy
    private bool attackMode;
    private bool inRange;  // check if player is in range
    private bool cooling; //check if player is cooling
    private float intTimer;

    private void Awake()
    {
        intTimer = timer;
        animator = GameObject.Find("EnemyAnimation").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(raycast.position, Vector2.left, raycastLenght, raycastMask);
            RaycastDebbuger();
        }

        // When player is detected
        if (hit.collider != null)
            EnemyLogic();
        else
            inRange = false;

        if (inRange == false)
        {
            //animator.SetBool("IsRun", false);
            StopAttack();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.gameObject;
            inRange = true;
        }
    }
    private void RaycastDebbuger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(raycast.position, Vector2.left * raycastLenght, Color.red);
        }
        if (distance < attackDistance)
        {
            Debug.DrawRay(raycast.position, Vector2.left * raycastLenght, Color.blue);
        }
    }

    private void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance > distance && cooling == false)
        {
            Attack();
        }
        if (cooling)
        {
            animator.SetBool("Attack", false);
        }
    
    
    }
    private void Move()
    {
        //animator.SetBool("IsRun", true);
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movespeed * Time.deltaTime);
        }
    }

    private void Attack()
    {
        timer = intTimer; // Reset Timeer when Player enter attack range
        attackMode = true;
        //animator.SetBool("IsRun", false);
        animator.SetBool("Attack", true);
    }

    private void StopAttack()
    {
        cooling = false;
        attackMode = false;
        animator.SetBool("Attack", false);

    }
}
