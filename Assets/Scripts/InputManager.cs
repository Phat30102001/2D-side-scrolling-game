using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public Rigidbody2D rb;
    //public GameObject npc;
    public PlayerInventory inventory;

    private float horizontal;
    private bool messageBoardOpened;

    private GameObject npc;
    private GameObject item;


    private void Awake()
    {
        instance = this;
    }

    public float Horizontal { get => horizontal; set => horizontal = value; }
    public GameObject Npc { get => npc; set => npc = value; }
    public bool MessageBoardOpened { get => messageBoardOpened; set => messageBoardOpened = value; }
    public GameObject Item { get => item; set => item = value; }

    public void Move(InputAction.CallbackContext context)
    {
        Horizontal= context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && PlayerMovement.instance.IsGrounded())
        {
            PlayerMovement.instance.Jumping();
        }

        // reduce jump height when player didn't hold jump button (jump cut)
        if (context.canceled && rb.velocity.y > 0)
        {
            PlayerMovement.instance.JumpCancel();
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed && !PlayerAttack.instance.isAttacking && PlayerMovement.instance.IsGrounded())
        {
            PlayerAttack.instance.Attacking();

        }
    }

    public void Heal(InputAction.CallbackContext context)
    {
        if (context.performed)
            PlayerHeal.instance.Healing();
    }

    public void Confirm(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            NPCDetect();
            ItemDetect();
        }
    }

    public void NPCDetect()
    {
        if (Npc == null) return;

        NPCBehaviour nPCBehaviour = Npc.GetComponent<NPCBehaviour>();

        if (nPCBehaviour.state != NPCState.TALKABLE) return;

        if (!MessageBoardOpened)
        {
            Npc.gameObject.GetComponent<NPCDialog>().StartDialog();
            MessageBoardOpened = true;
        }
        else
            FindObjectOfType<DialogManager>().NextMessage();
    }
    
    public void ItemDetect()
    {        
        if (Item == null) return;
        PlayerDetect playerDetect = Item.GetComponent<PlayerDetect>();
        if (!playerDetect.Detect()) return;
        switch (Item.tag)
        {
            case "Interactable":
                ItemSOReceiver itemSO = Item.GetComponent<ItemSOReceiver>();
                inventory.AddItem(itemSO);
                break;
            case "Gate":
                Debug.Log("door");
                DoorOpenSide door = Item.GetComponent<DoorOpenSide>();
                door.OpenDoor();
                break;
            case "Bonfire":
                Debug.Log("bonfire");
                break;
        }

        //Debug.Log("item detected");
    }
    


}
