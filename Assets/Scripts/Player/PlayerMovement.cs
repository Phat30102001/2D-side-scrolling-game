using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    private float jumpingForce=12;

    //check player facing side
    private bool isFacingRight = true;

    private GameObject playerAnimator;
    private Animator animator;

    private UnitStatReceiver unit;

    public float  kBCounter;
    public bool knockFromRight;

    private void Awake()
    {

        instance = this;
        playerAnimator = GameObject.Find("PlayerAnimator");
        animator = playerAnimator.GetComponent<Animator>();

        unit = GameObject.Find("PlayerStat").GetComponent<UnitStatReceiver>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.state != gameState.END) { 
            // player cant move when take damage (knockback havent been recoveried)
            if (kBCounter <= 0 )
            {
                this.horizontal = InputManager.instance.Horizontal;
                // horizontal*speed: make object move, horizontal==0 when user do not press left or right button
                rb.velocity = new Vector2(horizontal * unit.MovingSpeed, rb.velocity.y);
                animator.SetFloat("IsRun", Mathf.Abs(horizontal));
            }
            else
            {
                if(GameManager.instance.state!= gameState.END)
                {

                    animator.Play("PlayerDamaged");

                    rb.velocity = new Vector2(unit.KBForce,rb.velocity.y);

                    kBCounter -= Time.deltaTime;
                    }

        

                }
                //kBCounter = unit.KBTotalTime;
            
            // facing direction
            if (!isFacingRight && horizontal > 0f)
            {
                FlipSprite();
            }
            else if (isFacingRight && horizontal < 0f)
            {
                FlipSprite();
            }    
            JumpingAnimation();
        }
    }
    private void Update()
    {
        if (!IsGrounded()) 
            animator.SetBool("IsGround", false);
        else
            animator.SetBool("IsGround", true);
    }

    //public void Jump(InputAction.CallbackContext context)
    //{
    //    if (context.performed && IsGrounded())
    //    {
    //        rb.AddForce(Vector2.up * jumpingForce, ForceMode2D.Impulse);
    //    }
        
    //    // reduce jump height when player didn't hold jump button (jump cut)
    //    if(context.canceled && rb.velocity.y > 0)
    //    {
    //        rb.AddForce(Vector2.down * rb.velocity.y * 0.9f, ForceMode2D.Impulse);
    //    }
    //}

    public void Jumping()
    {
        //if (PlayerBehaviour.instace.state != PlayerState.IDLE) return;
         
        rb.AddForce(Vector2.up * jumpingForce, ForceMode2D.Impulse);
    }

    public void JumpCancel()
    {
        rb.AddForce(Vector2.down * rb.velocity.y * 0.9f, ForceMode2D.Impulse);
    }

    public void JumpingAnimation()
    {
        if (PlayerAttack.instance.isAirAttacking)
        {


            return;
        }
        //Debug.Log(PlayerAttack.instance.isAirAttacking);
        if (rb.velocity.y < jumpingForce && rb.velocity.y > 0f )
        {
            animator.SetBool("IsJump", true);
        }
        if (rb.velocity.y < 0f )
        {
            animator.SetBool("IsJump", false);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = playerAnimator.transform.parent.localScale;
        localScale.x *= -1f;
        playerAnimator.transform.parent.localScale = localScale;
    }

    //public void Move( InputAction.CallbackContext context)
    //{
    //    horizontal = context.ReadValue<Vector2>().x;
    //    //horizontal's always = 1
    //    animator.SetFloat("IsRun", Mathf.Abs(horizontal));
    //}
}
