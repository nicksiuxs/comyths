using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private float horizontal;
    private bool grounded;

    public float JumpForce = 250f;
    public float Speed = 10f;
    public float raySize = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");;;
        Debug.DrawRay(transform.position, Vector3.down * raySize, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, raySize))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Debug.Log("Saltando");
            Jump();
        }
    }

    private void Jump()
    {
        rigidbody.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(horizontal, rigidbody.velocity.y);
    }
}
