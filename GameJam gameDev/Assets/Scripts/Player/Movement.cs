using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // public variables
    public float MoveSpeed;
    public float JumpHeight;
    [Range(1f,1.20f)]public float fallMultiplier;

    // private variables
    private Rigidbody2D rb;
    private float _horizontal;

    private bool jump;
    private bool _isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MovementInputs()
    {
        _horizontal = Input.GetAxis("Horizontal") * MoveSpeed;
        jump = Input.GetKeyDown(KeyCode.Space);
        if (jump && isGrounded)
        {
            _isJumping = true;
        }
    }

    public void Move()
    {
        Vector2 vel;
        vel = _horizontal * Vector2.right + rb.velocity.y * Vector2.up;
        if(rb.velocity.y < 0)
        {
            vel = _horizontal * Vector2.right + (rb.velocity.y * fallMultiplier) * Vector2.up;
        }
        rb.velocity = vel;

        if(_isJumping)
        {
            rb.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            _isJumping = false;
        }
    }

    
    private bool isGrounded
    {
        get
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down, 1.1f);
            foreach(RaycastHit2D cast in hit)
            {
                if (cast.collider.tag == "Ground") return true;
            }
            return false;
        }
    }
}
