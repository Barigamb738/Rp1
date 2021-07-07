using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterController2D : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float move;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded;
    public Transform check;
    public float checkRadius;
    public LayerMask Ground;

    public int extraJumps;
    public int extraJumpValue;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(check.position, checkRadius, Ground);

        move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if(facingRight == false && move > 0)
        {
            Flip();
        }
        else if (facingRight != false && move < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        if(isGrounded)
        {
            extraJumps = extraJumpValue;
        }

        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0 )
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}