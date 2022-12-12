using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

public class Movement : MonoBehaviour
{
    // private variables
    [SerializeField] private DeveloperConsoleBehaviour dev;
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
        _horizontal = Input.GetAxis("Horizontal") * PlayerStats.MoveSpeed;
        jump = Input.GetKeyDown(KeyCode.Space);
        if (jump && isGrounded && !dev.uiCanvas.activeInHierarchy)
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
            vel = _horizontal * Vector2.right + (rb.velocity.y * PlayerStats.fallMultiplier) * Vector2.up;
            rb.velocity = Vector2.ClampMagnitude(vel, -9.81f);
        }
        rb.velocity = vel;

        if(_isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * PlayerStats.JumpHeight, ForceMode2D.Impulse);
            _isJumping = false;
        }
    }

    
    private bool isGrounded
    {
        get
        {
            RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, 0.3f, Vector2.down, 1.1f);
            foreach(RaycastHit2D cast in hit)
            {
                if (cast.collider.tag == "Ground") return true;
            }
            return false;
        }
    }
}
