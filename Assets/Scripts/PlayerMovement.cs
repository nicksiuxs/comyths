using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    private float horizontal;
    private bool grounded;
    private Vector3 initialPosition;

    public int lives;
    public float JumpForce;
    public float runSpeed;
    public float walkSpeed;
    public float raySize;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialPosition = new Vector3(transform.position.x, transform.position.y, 0);
        Debug.Log("Hola");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
        CheckGrounded();
    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
        else if (horizontal > 0f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        animator.SetBool("isRunning", horizontal != 0f);


        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        rigidbody.velocity = new Vector2(horizontal * currentSpeed, rigidbody.velocity.y);
    }

    private void Jump()
    {
        animator.SetBool("isJumping", true);
        rigidbody.AddForce(Vector2.up * JumpForce);
    }

    void CheckGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * raySize, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, raySize))
        {
            animator.SetBool("isJumping", false);
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }


    public void ValidateLives()
    {
        ResetPlayerPosition();
    }

    public void ResetPlayerPosition()
    {
        transform.position = initialPosition;
    }
}
