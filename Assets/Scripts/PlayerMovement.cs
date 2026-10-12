using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected float movement_speed = 10f;
    [SerializeField] protected float jump_height = 21f;
    [SerializeField] protected float max_fall_speed = 20f;

    private Vector2 moveInput;
    public Rigidbody2D rb;

    private bool is_grounded = true;

    [SerializeField] private GameRules gamerules;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (is_grounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump_height);
        }
    }

    private void Update()
    {
        // Checks if platform tile is to right or left to prevent jittery clipping
        if (!((moveInput.x > 0 && Physics2D.Raycast(transform.position, Vector2.right, 0.3f, LayerMask.GetMask("Ground"))) ||
             moveInput.x < 0 && Physics2D.Raycast(transform.position, Vector2.left, 0.3f, LayerMask.GetMask("Ground"))))
        {
            // Only takes movement from x axis
            transform.Translate(new Vector2(moveInput.x * Time.deltaTime * movement_speed, 0));
        }
        
        // Casts rays below player to check for ground
        is_grounded = Physics2D.Raycast(new Vector2(transform.position.x - 0.25f, transform.position.y), Vector2.down, 0.5f, LayerMask.GetMask("Ground"))
                   || Physics2D.Raycast(new Vector2(transform.position.x + 0.25f, transform.position.y), Vector2.down, 0.5f, LayerMask.GetMask("Ground"));

        // Detects if player has fallen off screen
        if (transform.position.y < -10f)
        {
            rb.linearVelocity = Vector2.zero;
            gamerules.Die();
        }
    }

    private void FixedUpdate()
    {
        // Caps maximum fall speed to prevent physics glitches
        if (rb.linearVelocityY < -max_fall_speed)
        {
            rb.linearVelocityY = -max_fall_speed;
        }
    }
}
