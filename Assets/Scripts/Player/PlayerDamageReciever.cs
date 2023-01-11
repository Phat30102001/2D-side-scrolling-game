using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReciever : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private UnitStatReceiver unit;


    private void Awake()
    {
        unit = GameObject.Find("PlayerStat").GetComponent<UnitStatReceiver>();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        playerMovement.kBCounter = playerMovement.kBTotalTime;
    //        //Debug.Log("Contact damage");
    //        if (collision.transform.position.x >= transform.position.x && playerMovement.kBForce > 0)
    //            playerMovement.kBForce *= -1;
    //        if (collision.transform.position.x < transform.position.x && playerMovement.kBForce<0)
    //            playerMovement.kBForce *= -1;
    //    }

    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerMovement.kBCounter = unit.KBTotalTime;
            //Debug.Log("Contact damage");

            //playerHealth.TakeDamage(collision.gameObject.)
            unit.TakeDamage(collision.transform.parent.GetChild(2).GetComponent<UnitStatReceiver>().Damage);
            if (collision.transform.parent.position.x >= transform.position.x && unit.KBForce > 0)
                unit.KBForce *= -1;
            if (collision.transform.parent.position.x < transform.position.x && unit.KBForce < 0)
                unit.KBForce *= -1;
        }
    }
}
