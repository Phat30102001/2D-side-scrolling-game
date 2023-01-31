using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AtiveBossFight : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bossName;

    [SerializeField] private GameObject boss;
    [SerializeField] private Transform activePoint;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject room;

    public List<GameObject> doorList;


    private void Start()
    {
        bossName.gameObject.SetActive(false);
        boss.SetActive(false);
    }
    private void FixedUpdate()
    {
        float dis = DisToPlayer();
        if (dis <=0.5 && room.activeSelf==true)
        {
            boss.SetActive(true);
            DisplayBossName();
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

    public void DisplayBossName()
    {
        bossName.gameObject.SetActive(true);
        bossName.text = "Reaper";
    }
}
