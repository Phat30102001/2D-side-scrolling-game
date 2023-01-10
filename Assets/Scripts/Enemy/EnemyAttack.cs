using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //private Transform hitbox;

    // for get disToPlayer
    private EnemyMovement enemyMovement;

    private EnemyBehaviour enemyBehaviour;

    private void Awake()
    {
        //hitbox = gameObject.transform.GetChild(1);
        enemyMovement = gameObject.GetComponent<EnemyMovement>();
        enemyBehaviour = gameObject.GetComponent<EnemyBehaviour>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (enemyMovement.DistanceToPlayer() <= AtiveAttackRange())
    //        enemyBehaviour.UpdateEnemyBehaivour(EnemyState.ATTACK);

    //}
    //private float AtiveAttackRange()
    //{

    //    return Vector2.Distance(gameObject.transform.position, hitbox.position);
    //}

}
