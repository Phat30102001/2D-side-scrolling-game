using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [SerializeField] private float horizontal;
    [SerializeField] private float speed;
    [SerializeField] private float jumpingForce;

    //check player facing side
    private bool isFacingRight = true;

    private GameObject playerAnimator;
    private Animator animator;

    private void Awake()
    {
        playerAnimator = GameObject.Find("PlayerAnimator");
        animator = playerAnimator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // horizontal*speed: make object move, horizontal==0 when user do not press left or right button
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

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
    private void Update()
    {
        if (!IsGrounded()) 
            animator.SetBool("IsGround", false);
        else
            animator.SetBool("IsGround", true);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpingForce, ForceMode2D.Impulse);
        }
        
        // reduce jump height when player didm't hold jump button (jump cut)
        if(context.canceled && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * rb.velocity.y * 0.9f, ForceMode2D.Impulse);
        }
    }
    public void JumpingAnimation()
    {
        if (rb.velocity.y < jumpingForce && rb.velocity.y > 0f)
        {
            animator.SetBool("IsJump", true);
        }
        if (rb.velocity.y < 0f)
        {
            animator.SetBool("IsJump", false);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale =playerAnimator.transform.localScale;
        localScale.x *= -1f;
        playerAnimator.transform.localScale = localScale;
    }

    public void Move( InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        //horizontal's always = 1
        animator.SetFloat("IsRun", Mathf.Abs(horizontal));
    }

}
