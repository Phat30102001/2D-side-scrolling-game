using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
public class BossDefeated : Action
{
    [SerializeField] private GameObject boss;

    public List<GameObject> doorList;

    public override void OnStart()
    {
        boss = gameObject;

    }

    public override TaskStatus OnUpdate()
    {

        foreach (GameObject door in doorList)
        {
            OpenDoor(door);
        }
        boss.transform.parent.gameObject.SetActive(false);
        return TaskStatus.Success;
    }

    public void OpenDoor(GameObject door)
    {
        door.GetComponent<BoxCollider2D>().isTrigger = true;
        door.GetComponent<Animator>().Play("DoorOpen");
    }
}
