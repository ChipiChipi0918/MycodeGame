using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.ParticleSystem;

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

    public GameObject shoot;

    public GameObject shake;

    public GameObject reload;

    public GameObject bk1,bk2;

    public GameObject laserT;

    public GameObject bulletUI;

    public GameObject ParticlePrefab_Bullet;

    public GameObject ParticlePrefab_Die;

    public int BulletConunt = 5;

    public float slowFactor = 0.1f;
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

        rb.gravityScale = 3f;
    }
    public void ReloadingEnd()
    {
        BulletConunt = 5;
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            BulletConunt = 0;
            reload.GetComponent<Gun>().BulletReload();
        }
        
        if (Input.GetKeyDown(KeyCode.K) && BulletConunt >0)             //Æò¼Ò²¨
        {
            rb.gravityScale = 2f;
            ReturnScale();

            scaleX = 0.89f; scaleY = 1.02f;

            transform.position += Vector3.left * 0.3f;
            shoot.GetComponent<Shoot>().Shooting();
            shake.GetComponent<Camera>().Shaking();
            reload.GetComponent<Gun>().reloading();
            bulletUI.GetComponent<BulletUI>().BulletCounting();
            GameObject Particle = Instantiate(ParticlePrefab_Bullet) as GameObject;
            Particle.transform.SetParent(this.transform, false);

            BulletConunt--;

            
        }
        if (BulletConunt <= 0)
        {
            
            
            laserT.GetComponent<laser>().laserOff();

        }
        else
        {
            laserT.GetComponent<laser>().ResetA();
        }
        
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    reload.GetComponent<Gun>().BulletReload();
        //}

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

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Sawblade")
        {
            
            Time.timeScale = slowFactor;

            Invoke("Die", 0.2f);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BK1")
        {
            bk1.GetComponent<BG1>().EnterBk1();
        }
        if (collision.gameObject.tag == "BK2")
        {
            bk2.GetComponent<BG2>().EnterBk2();
        }


    }
    void Die()
    {
        GameObject Particle = Instantiate(ParticlePrefab_Die) as GameObject;
        Particle.transform.SetParent(this.transform, false);
        shake.GetComponent<Camera>().superShaking();
        Time.timeScale = 1f;

        //transform.localScale = new Vector3(0.001f, 0.001f, -1f);
        scaleX = 0.001f;
        scaleY = 0.001f;
        Invoke("Destory", 0.25f);
    }

    void Destory()
    {
        Destroy(gameObject);
    }
}
