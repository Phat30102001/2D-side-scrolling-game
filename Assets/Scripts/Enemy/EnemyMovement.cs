using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;

    private Transform playerTransform;

    public GameObject[] waypoint;
    int currentWaypointIndex = 0;

    public UnitStat unit;

    private EnemyBehaviour enemyBehaviour;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").transform;
        enemyBehaviour = gameObject.GetComponent<EnemyBehaviour>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //if (enemyBehaviour.state==EnemyState.CHASE)
        //{
        //    // chase player
        //    ChasePLayer();
        //}
        //if (enemyBehaviour.state == EnemyState.PATROL)
        //{
        //    // dont chase player
        //    Patrol();
        //}
    }
    public void ChasePLayer()
    {
        //if (DistanceToPlayer() > unit.DetectRange)
        //{
        //    enemyBehaviour.UpdateEnemyBehaivour(EnemyState.PATROL);
        //}
        int facingSide = enemyBehaviour.CheckFacingSide(playerTransform);
        rb.velocity = new Vector2(unit.MovingSpeed * facingSide, rb.velocity.y);
        transform.localScale = new Vector2(facingSide, 1);
    }
    public void Patrol()
    {

        //if (DistanceToPlayer() <= unit.DetectRange) 
        //{
        //    enemyBehaviour.UpdateEnemyBehaivour(EnemyState.CHASE); 
        //}
        int facingSide= enemyBehaviour.CheckFacingSide(waypoint[currentWaypointIndex].transform);

        if (Vector2.Distance( waypoint[currentWaypointIndex].transform.position, transform.position) < .1f)
        {

            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoint.Length)
            {
                currentWaypointIndex = 0;
            }
            enemyBehaviour.UpdateEnemyBehaivour(EnemyState.REST);
        }
        
        transform.localScale = new Vector2(facingSide, 1);
        transform.position = Vector2.MoveTowards(transform.position, waypoint[currentWaypointIndex].transform.position, Time.deltaTime * unit.MovingSpeed);
       
    }

    public IEnumerator  Rest()
    {
        yield return new WaitForSeconds(2f);
        //if (DistanceToPlayer() <= unit.DetectRange)
        //{
        //    enemyBehaviour.UpdateEnemyBehaivour(EnemyState.CHASE);
        //}
        //else
        //    enemyBehaviour.UpdateEnemyBehaivour(EnemyState.PATROL);
    }
    public float DistanceToPlayer()
    {
        return Vector2.Distance(playerTransform.position, transform.position);
    }
}

