using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;

    public float scaleX = 1f;
    public float scaleY = 1f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isDashing;

    private float dashTime;
    private Vector2 moveDirection;

    public GameObject shootingParticle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void ReturnScale()
    {
        StartCoroutine("PrintAfterWait");


    }
    IEnumerator PrintAfterWait()
    {
        yield return new WaitForSeconds(0.16f);
        scaleX = 0.9f; scaleY = 0.9f;
        yield return new WaitForSeconds(0.16f);
        scaleX = 1f; scaleY = 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            transform.position += Vector3.left * 0.2f;
            shootingParticle.GetComponent<ShootingParticle>().inputK();
        }


        transform.localScale = new Vector3(scaleX, scaleY, -1f);

        float moveInput = Input.GetAxis("Horizontal");
        moveDirection = new Vector2(moveInput, 0);

      
        if (Input.GetButtonDown("Jump") && isGrounded && !isDashing)
        {
            Jump();
        }

    
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartDash();
        }

        
        if (isDashing)
        {
            Dash();
        }
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            Move();
        }
    }

    private void Move()
    {
        
        Vector2 targetVelocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
        rb.velocity = targetVelocity;
    }

    private void Jump()
    {
        scaleX = 0.8f; scaleY = 1.2f;
        ReturnScale();

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
    }

    private void StartDash()
    {
        isDashing = true;
        
        dashTime = dashDuration;
        rb.gravityScale = 1.5f;
    }

    private void Dash()
    {
        scaleX = 1.15f; scaleY = 0.85f;

        
        ReturnScale();

        rb.velocity = new Vector2(moveDirection.x * dashSpeed, rb.velocity.y);
        dashTime -= Time.deltaTime;
        if (dashTime <= 0)
        {
            isDashing = false;
            rb.gravityScale = 3f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.contacts[0].normal.y > 0.5f)
        {
            
            isGrounded = true;
        }
    }
}
