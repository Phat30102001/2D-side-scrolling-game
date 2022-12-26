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
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.gameObject;
            inRange = true;
        }
    }
}
