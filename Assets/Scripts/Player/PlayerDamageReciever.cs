using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReciever : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerMovement.kBCounter = playerMovement.kBTotalTime;
            //Debug.Log("Contact damage");
            if (collision.transform.position.x >= transform.position.x && playerMovement.kBForce > 0)
                playerMovement.kBForce *= -1;
            if (collision.transform.position.x < transform.position.x && playerMovement.kBForce<0)
                playerMovement.kBForce *= -1;
        }
        
    }

}
