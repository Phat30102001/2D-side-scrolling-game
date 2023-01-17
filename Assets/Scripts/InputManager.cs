using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public Rigidbody2D rb;
    //public GameObject npc;

    private float horizontal;
    private bool messageBoardOpened;

    private GameObject npc;


    private void Awake()
    {
        instance = this;
    }

    public float Horizontal { get => horizontal; set => horizontal = value; }
    public GameObject Npc { get => npc; set => npc = value; }
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
        }
    }

    public void NPCDetect()
    {
        //foreach (NPCBehaviour npc in Object.FindObjectsOfType(typeof(NPCBehaviour)))
        //{
        if (npc == null) return;

        NPCBehaviour nPCBehaviour = npc.GetComponent<NPCBehaviour>();

        if (nPCBehaviour.state != NPCState.TALKABLE) return;

        if (!messageBoardOpened)
        {
            npc.gameObject.GetComponent<NPCDialog>().StartDialog();
            messageBoardOpened = true;
        }
        else
            FindObjectOfType<DialogManager>().NextMessage();

        //}
    }

    public void GetInteractableObject(GameObject npc)
    {
        if (npc == null) return;
    }
}
