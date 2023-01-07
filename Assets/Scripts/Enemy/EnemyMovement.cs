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

    float distanceToPlayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //if (EnemyBehaviour.instance.state==EnemyState.CHASE)
        //{
        //    // chase player
        //    ChasePLayer();
        //}
        //if (EnemyBehaviour.instance.state == EnemyState.PATROL)
        //{
        //    // dont chase player
        //    Patrol();
        //}
    }
    public void ChasePLayer()
    {
        distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);
        if (distanceToPlayer > 5)
        {
            EnemyBehaviour.instance.UpdateEnemyBehaivour(EnemyState.PATROL);
        }
        int facingSide = EnemyBehaviour.instance.CheckFacingSide(playerTransform);
        rb.velocity = new Vector2(unit.MovingSpeed * facingSide, rb.velocity.y);
        transform.localScale = new Vector2(facingSide, 1);
    }
    public void Patrol()
    {
        distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);
        if (distanceToPlayer <= unit.DetectRange) 
        {
            EnemyBehaviour.instance.UpdateEnemyBehaivour(EnemyState.CHASE); 
        }
        int facingSide= EnemyBehaviour.instance.CheckFacingSide(waypoint[currentWaypointIndex].transform);

        if (Vector2.Distance( waypoint[currentWaypointIndex].transform.position, transform.position) < .1f)
        {

            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoint.Length)
            {
                currentWaypointIndex = 0;
            }
            EnemyBehaviour.instance.UpdateEnemyBehaivour(EnemyState.REST);
        }
        
        transform.localScale = new Vector2(facingSide, 1);
        transform.position = Vector2.MoveTowards(transform.position, waypoint[currentWaypointIndex].transform.position, Time.deltaTime * unit.MovingSpeed);
       
    }

    public IEnumerator  Rest()
    {
        yield return new WaitForSeconds(2f);
        distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);
        if (distanceToPlayer <= unit.DetectRange)
        {
            EnemyBehaviour.instance.UpdateEnemyBehaivour(EnemyState.CHASE);
            Debug.Log(unit.AtiveAttackRange);
        }
        else
            EnemyBehaviour.instance.UpdateEnemyBehaivour(EnemyState.PATROL);
    }
}

