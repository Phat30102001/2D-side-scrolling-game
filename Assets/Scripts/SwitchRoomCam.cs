using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRoomCam : MonoBehaviour
{
    public GameObject Cam;
    public GameObject enemies;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&&!collision.isTrigger)
            Cam.SetActive(true);

            
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&&!collision.isTrigger)
            Cam.SetActive(false);
    }

    //public void ObjectReduce(bool decision, GameObject gameObject)
    //{
    //    gameObject.SetActive(decision);
    //}
}
