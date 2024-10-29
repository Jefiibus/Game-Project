using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private CapsuleCollider2D cc;
    private damageable damageable;

    Vector2 moveInput;
    TouchingDirections touchingDirections;

    public float CurrentMoveSpeed { get 
        {
            if(IsMoving && !touchingDirections.IsOnWall)
            {
                return moveSpeed;
            }
            else
            {
                return 0;
            }
        } }

    public bool IsMoving { get
        { 
            {
            return _isMoving;
            } 
        }
        private set
        {
            _isMoving = true;
        } 
    }
    private bool _isMoving = false;
    public bool _IsFacingRight = true;

    public bool IsFacingRight { get { return _IsFacingRight; } private set {
            if (_IsFacingRight != value) 
            { 
                transform.localScale *= new Vector2(-1,1);
            }
            _IsFacingRight = value;
                } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        damageable = GetComponent<damageable>();
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Gets player input and checks if the player is moving
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
        SetFacingDirection(moveInput);

    }
    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !IsFacingRight)
        {
            //right
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            //left
            IsFacingRight = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && touchingDirections.IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
      if (col.collider.CompareTag("Enemy"))
        {
            damageable.Hit(1);
        }
    }
}
