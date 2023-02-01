using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReciever : MonoBehaviour
{
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
        if (collision.gameObject.tag == "Enemy"&&GameManager.instance.state!=gameState.END)
        {
            PlayerMovement.instance.kBCounter = unit.KBTotalTime;
            //Debug.Log("Contact damage");

            //playerHealth.TakeDamage(collision.gameObject.)
            unit.TakeDamage(collision.transform.parent.GetComponentInChildren<UnitStatReceiver>().Damage);

            if (unit.CurrentHp <= 0)
            {
                GameManager.instance.UpdateGameState(gameState.END);
            }
                

            if (collision.transform.parent.position.x >= transform.position.x && unit.KBForce > 0)
                unit.KBForce *= -1;
            if (collision.transform.parent.position.x < transform.position.x && unit.KBForce < 0)
                unit.KBForce *= -1;
        }
    }
}
