using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenSide : NpcTalking
{

    // side = -1, player can open on the right ...
    [Range(-1,1)]
    [SerializeField] private int side;

    private Animator doorAnimator;

    private GameObject player;
    private BoxCollider2D doorCollider;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find("Player");
        doorCollider = gameObject.GetComponent<BoxCollider2D>();
        doorAnimator=GetComponent<Animator>();
    }
    private void Update()
    {
        if (gameObject.transform.GetChild(0).gameObject.activeSelf != true && PanelOpened)
        {
            ZeroText();
        }
    }
    public float GetPlayerSide()
    {
        float playerSide =  player.transform.position.x-transform.position.x ;
        return playerSide;
    }
    
    public void OpenDoor()
    {
        float open = GetPlayerSide() * side;
        if (open > 0)
        {
            Debug.Log("open");
            doorCollider.isTrigger = true;
            doorAnimator.Play("DoorOpen");
            //doorAnimator.SetTrigger("Open");
        }

        else
        {
            Talk();
            Debug.Log("Does not open from this side");

        }
            
    }

}
