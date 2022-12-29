using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float detectRange;
    //public float moveSpeed;
    Rigidbody2D rb;

    Animator animator;
    public UnitStat unit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);
        if (distanceToPlayer <= detectRange)
        {
            // chase player
            ChasePLayer();
        }
        else
        {
            // dont chase player
            StopChasePLayer();
        }
    }
    void ChasePLayer()
    {
        animator.SetBool("IsRun", true);
        if (transform.position.x < playerTransform.position.x)
        {
            rb.velocity = new Vector2(unit.movingSpeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        if (transform.position.x > playerTransform.position.x)
        {
            rb.velocity = new Vector2(-unit.movingSpeed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
    }
    void StopChasePLayer()
    {
        animator.SetBool("IsRun", false);
    }
}
