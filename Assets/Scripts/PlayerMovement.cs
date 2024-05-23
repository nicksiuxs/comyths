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

    public float JumpForce = 250f;
    public float Speed = 10f;
    public float raySize = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        animator.SetBool("isJumping",true);
        rigidbody.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(horizontal * Speed, rigidbody.velocity.y);
    }
}
