using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenSide : MonoBehaviour
{

    // side = -1, player can open on the right ...
    [Range(-1,1)]
    [SerializeField] private int side;

    public Animator animator;

    private GameObject player;
    private BoxCollider2D doorCollider;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find("Player");
        doorCollider = gameObject.GetComponent<BoxCollider2D>();
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
            animator.Play("DoorOpen");
        }
            
        else
            Debug.Log("Does not open from this side");
    }

}
