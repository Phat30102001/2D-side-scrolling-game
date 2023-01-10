using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyState{CHASE,PATROL,ATTACK,REST}
public class EnemyBehaviour : MonoBehaviour
{
    
    private Transform playerTransform;
    private Transform hitbox;
    public UnitStat unit;
    public EnemyState state;
    //public static EnemyBehaviour instance;

    //public UnitStat unit;

    private EnemyMovement enemyMovement;

    private Animator animator;
    private EnemyAnimationEvent enemyAniEvent;
    int facingSide;

    //private int facingSide;

    private void Awake()
    {
        //instance = this;

        enemyMovement = gameObject.GetComponent<EnemyMovement>();
        
        playerTransform = GameObject.Find("Player").transform;
        hitbox = gameObject.transform.GetChild(1);
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
        enemyAniEvent= gameObject.transform.GetChild(0).GetComponent<EnemyAnimationEvent>();
    }
    private void Start()
    {
        UpdateEnemyBehaivour(EnemyState.PATROL);
    }
    private void Update()
    {
        if (DistanceToPlayer() >= unit.DetectRange&& enemyAniEvent.CheckAttackAvailabled())
            UpdateEnemyBehaivour(EnemyState.PATROL);
        if (DistanceToPlayer() < unit.DetectRange&& DistanceToPlayer() > AtiveAttackRange()&&enemyAniEvent.CheckAttackAvailabled())
            UpdateEnemyBehaivour(EnemyState.CHASE);
        if (DistanceToPlayer() <= AtiveAttackRange())
            UpdateEnemyBehaivour(EnemyState.ATTACK);

        //switch (state)
        //{
        //    case EnemyState.CHASE:
        //        animator.SetBool("IsRun", true);
        //        enemyMovement.ChasePLayer();
        //        break;
        //    case EnemyState.PATROL:
        //        animator.SetBool("IsRun", true);
        //        enemyMovement.Patrol();
        //        break;
        //    case EnemyState.ATTACK:
        //        animator.Play("HalberdSkeletonAttack");
        //        break;
        //    case EnemyState.REST:
        //        animator.SetBool("IsRun", false);
        //        StartCoroutine( enemyMovement.Rest());
        //        break;

        //}
    }


    public void UpdateEnemyBehaivour(EnemyState newState)
    {
        state = newState;
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
                if (enemyAniEvent.CheckAttackAvailabled())
                {
                    Debug.Log(enemyAniEvent.CheckAttackAvailabled());
                    animator.Play("HalberdSkeletonAttack");
                    //enemyAniEvent.AttackUnavailable();
                }
                    
                break;
            case EnemyState.REST:
                animator.SetBool("IsRun", false);
                StartCoroutine(enemyMovement.Rest());
                break;

        }
    }

    public int CheckFacingSide(Transform target)
    {
        if (transform.position.x > target.position.x)
            return -1;
        return 1;

    }

    public float DistanceToPlayer()
    {
        return Vector2.Distance(playerTransform.position, transform.position);
    }

    public float AtiveAttackRange()
    {

        return Vector2.Distance(gameObject.transform.position, hitbox.position);
    }
}
