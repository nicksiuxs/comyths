using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    private float horizontal;
    private bool grounded;
    private Vector3 initialPosition;

    public int lives;
    public int fragments;
    public float JumpForce;
    public float runSpeed;
    public float walkSpeed;
    public float raySize;
    public AudioClip jumpSound;
    public AudioClip walkSound;

    [SerializeField] private int vida;
    [SerializeField] private int vidaMaxima;
    [SerializeField] private HealthBarController healthBarController;

    public float footstepInterval = 0.1f;
    public bool isStepsSoundAvailable = true;
    private float footstepTimer;

    public GameObject lifesController;
    public GameObject fragmentController;

    // Start is called before the first frame update
    void Start()
    {
        vida = vidaMaxima;
        fragments = 0;
        SetFragments(fragments);
        healthBarController.InitializeHealthBar(vida);
        lives = 5;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        footstepTimer = footstepInterval;
        SetCurrentPosition();
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

        footstepTimer -= Time.deltaTime;

        // Si el temporizador llega a cero, reproduce el sonido del paso
        if (footstepTimer <= 0f && isStepsSoundAvailable && grounded)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(walkSound);
            footstepTimer = footstepInterval;  // Reinicia el temporizador
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            isStepsSoundAvailable = true;
        }
        else if (horizontal > 0f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            isStepsSoundAvailable = true;
        }
        else
        {
            isStepsSoundAvailable = false;

        }


        animator.SetBool("isRunning", horizontal != 0f);


        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        rigidbody.velocity = new Vector2(horizontal * currentSpeed, rigidbody.velocity.y);
    }

    private void Jump()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(jumpSound);
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

    public void SetCurrentPosition()
    {
        initialPosition = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void ValidateLives()
    {
        lives--;
        LifesController lifesScript = lifesController.GetComponent<LifesController>();
        lifesScript.SetLivesCounter(lives);
        if (lives == 0)
        {
            Debug.Log("Moriste");
        }
        else
        {
            ResetPlayerPosition();
        }
    }

    public void SetFragments(int fragments)
    {
        FragmentsController fragmentScript = fragmentController.GetComponent<FragmentsController>();
        fragmentScript.SetFragmentCounter(fragments);
    }

    public void ResetPlayerPosition()
    {
        transform.position = initialPosition;
    }

    public void GetFragment()
    {
        fragments++;
        if (fragments >= 5)
        {
            SceneManager.LoadSceneAsync("Final");
        }
        else
        {
            SetFragments(fragments);
        }
    }

    public void HaveDamage()
    {
        vida--;
        healthBarController.ChangeActualLife(vida);
        if (vida <= 0)
        {
            lives -= 1;
            LifesController lifesScript = lifesController.GetComponent<LifesController>();
            lifesScript.SetLivesCounter(lives);
            vida = vidaMaxima;
            healthBarController.InitializeHealthBar(vida);
        }
    }

    public int GetLives()
    {
        return lives;
    }
}
