using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyState{CHASE,PATROL,ATTACK,REST}
public class EnemyBehaviour : MonoBehaviour
{
    
    public EnemyState state;
    public static EnemyBehaviour instance;

    //public UnitStat unit;

    private EnemyMovement enemyMovement;

   

    Animator animator;


    int facingSide;

    //private int facingSide;

    private void Awake()
    {
        instance = this;

        enemyMovement = gameObject.GetComponent<EnemyMovement>();
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();

    }
    private void Start()
    {
        UpdateEnemyBehaivour(EnemyState.PATROL);
    }
    private void FixedUpdate()
    {
        switch (state)
        {
            case EnemyState.CHASE:
                animator.SetBool("IsRun", true);
                enemyMovement.ChasePLayer();
                break;
            case EnemyState.PATROL:
                animator.SetBool("IsRun", true);
                enemyMovement.Patrol();
                break;
            case EnemyState.ATTACK:
                break;
            case EnemyState.REST:
                animator.SetBool("IsRun", false);
                StartCoroutine( enemyMovement.Rest());
                break;

        }
    }

    public void UpdateEnemyBehaivour(EnemyState newState) => state = newState;

    public int CheckFacingSide(Transform target)
    {
        if (transform.position.x > target.position.x)
            return -1;
        return 1;

    }
}
