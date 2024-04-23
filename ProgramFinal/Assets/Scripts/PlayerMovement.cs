using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 6f;
    private float jumpImpulse = 5f;
    Vector2 moveInput;
    TouchingDirections touchingDirections;

    public float CurrentMoveSpeed {  get
        {
            if(IsMoving && !touchingDirections.IsOnWall)
            {
                return walkSpeed;
            }
            else
            {
                // idle speed is 0
                return 0;
            }
        } 
    }

    // determine if the player is moving
    [SerializeField]
    private bool _isMoving = false;
    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool("IsMoving", value);
        }
    }

    // change sprite based on direction the player is facing
    public bool _isFacingRight = true;
    public bool IsFacingRight
    {
        get
        {
            return _isFacingRight;
        }
        private set
        {
            if(_isFacingRight != value)
            {
                // Flip the local scale to make the player face the opposite direction
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    Rigidbody2D rb; 
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    private void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);

        // need to check for switching gravity input in the player script, rather than the gravity script (because that script only applies to objects, not the player)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetTrigger(AnimationStrings.spell);
        }
    }


    // function to check for movement and and affect player accordingly
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);

        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);
    }

    // determine direction for purpose of flipping player sprite to face that direction
    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            // Face right
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            // Face left
            IsFacingRight = false;
        }
    }

    // jump and play animation upon input
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started && touchingDirections.IsGrounded)
        {
            animator.SetTrigger(AnimationStrings.jump);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }
}
