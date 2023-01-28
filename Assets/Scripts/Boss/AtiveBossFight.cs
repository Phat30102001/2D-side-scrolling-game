using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtiveBossFight : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private Transform activePoint;
    [SerializeField] private Transform player;


    public List<GameObject> doorList;


    private void Start()
    {
        boss.SetActive(false);
    }
    private void FixedUpdate()
    {
        float dis = DisToPlayer();
        if (dis <=0.5)
        {
            boss.SetActive(true);
            foreach(GameObject door in doorList) 
            {
                CloseDoor(door);
            }
        }
    }

    public float DisToPlayer()
    {
        float dis=activePoint.position.x-player.position.x;
        return dis;
    }

    public void CloseDoor(GameObject door)
    {
        door.GetComponent<BoxCollider2D>().isTrigger = false;
        door.GetComponent<Animator>().Play("DoorClose");
    }
}
