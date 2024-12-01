using System.Collections;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
//using UnityEngine.UIElements;
using static UnityEngine.ParticleSystem;

public class Player : MonoBehaviour
{



    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float attackSpeed = 0.6f;
    public int maxBullet = 5;
    public float damage = 1;

    public float xp = 0;
    public float Lv = 1;
    public float maxXp = 5;
    public int UpgradeChance = 1;

    public float scaleX = 1f;
    public float scaleY = 1f;

    private SpriteRenderer spr;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isDashing;

    public bool shootingOk = true;
    public bool isreloading = false;

    public Slider EXPSlider;
    public Slider MeterSlider;

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

    public GameObject dieUi;

    public GameObject XpUi;
    public GameObject lvBoxUi;

    public GameObject result;

    public float dashCool = 0.2f;
    private bool dashOk = true;

    public int BulletConunt = 5;
    
    public float slowFactor = 0.1f;

    private int chooseSound;

    public Sprite Lee;

    public AudioClip[] arrAudio;

    AudioSource myaudio;

    public Button btn1,btn2,btn3,btn4;

    public bool automaticFire = false;

    public float resultplayerpos;
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
        spr = GetComponent<SpriteRenderer>();

        myaudio = this.GetComponent<AudioSource>();

        //btn1 = GameObject.Find("Attack").GetComponent<Button>();
        //btn1.onClick.AddListener(Attack);

        //btn2 = GameObject.Find("AttackSpeed").GetComponent<Button>();
        //btn2.onClick.AddListener(AttackSpeed);

        //btn3 = GameObject.Find("BulletUp").GetComponent<Button>();
        //btn3.onClick.AddListener(BulletUp);

        //btn4 = GameObject.Find("Speed").GetComponent<Button>();
        //btn4.onClick.AddListener(Speed);


    }
    public void Attack()
    {
        //btn1.onClick.RemoveAllListeners();
        Debug.Log("dedede");
        damage += 0.5f;
        UpgradeChance--;
    }
    public void AttackSpeed()
    {
        //btn2.onClick.RemoveAllListeners();
        if (attackSpeed > 0.1f)
        {
            attackSpeed -= 0.1f;
            
        }
        //else
        //{
        //    attackSpeed = 0.1f;
        //}
        UpgradeChance--;
    }
    public void BulletUp()
    {
        //btn3.onClick.RemoveAllListeners();
        maxBullet++;
        BulletConunt = maxBullet;
        UpgradeChance--;
    }
    public void Speed()
    {
        //btn4.onClick.RemoveAllListeners();
        moveSpeed += 0.5f;
        jumpForce += 0.09f;
        dashSpeed += 0.2f;
        UpgradeChance--;
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

    
    void Update()
    {
        if(transform.position.x >= 200)
        {
            shake.GetComponent<Bgm>().BossSound();
        }
        if(attackSpeed <= 0.1f)
        {
            attackSpeed = 0.1f;
        }
        EXPSlider.maxValue = maxXp;
        EXPSlider.value = xp;

        MeterSlider.maxValue = 200;
        MeterSlider.value = transform.position.x;
        if (UpgradeChance > 0)
        {
            btn1.gameObject.SetActive(true);
            btn2.gameObject.SetActive(true);
            btn3.gameObject.SetActive(true);
            btn4.gameObject.SetActive(true);
        }
        else
        {
            btn1.gameObject.SetActive(false);
            btn2.gameObject.SetActive(false);
            btn3.gameObject.SetActive(false);
            btn4.gameObject.SetActive(false);
        }
        if (maxXp <= xp)
        {
            myaudio.Stop();
            myaudio.clip = arrAudio[2];
            myaudio.Play();

            lvBoxUi.GetComponent<LvBoxUi>().LvUp();
            xp = 0;
            UpgradeChance++;
            Lv++;
            maxXp++;
        }
        //이현우
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log("ㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋ");
            spr.sprite = Lee;
        }

        

        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1;
        }*/

        /*EXPSlider.value = Score;
        if (Score >= LevelCount) 
        {
            Score = 0;
        }*/

        Reload();

        Bulletshoot();

        
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


        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && dashOk == true)
        {
            dashOk = false;
            StartDash();
            Invoke("DashCool",dashCool);

            Debug.Log(dashOk);
        }
        

        if (isDashing)
        {
            Dash();
        }
    }
    void DashCool()
    {
        dashOk = true;
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
        rb.velocity = Vector2.zero;
        isDashing = true;

        dashTime = dashDuration;
        rb.gravityScale = 1.5f;
    }

    private void Dash()
    {
        scaleX = 1.15f; scaleY = 0.85f;
        rb.velocity = Vector2.zero;

        ReturnScale();

        rb.velocity = new Vector2(moveDirection.x * dashSpeed, rb.velocity.y);
        dashTime -= Time.deltaTime;
        if (dashTime <= 0)
        {
            isDashing = false;
            rb.gravityScale = 3f;
        }
    }
    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) || BulletConunt <= 0)
        {
            isreloading = true;
            BulletConunt = -1; //블렛 카운트 -1일때는 리로딩 상황
            reload.GetComponent<Gun>().BulletReload();
            bulletUI.GetComponent<BulletUI>().BulletReload();
        }
        
    }
    public void ReloadingEnd()
    {
        BulletConunt = maxBullet;
        Invoke("d", 0.26f);
        isreloading = true;
    }
    public void d()
    {
        isreloading = false;
    }
    void GunCooltime()
    {
        
        shootingOk = true;
        laserT.GetComponent<laser>().ResetA();
        
        
    }
    private void Bulletshoot()
    {
        /*if (attackSpeed <= 0.2f)
        {
            automaticFire = true;
        }*/
        
        if (Input.GetMouseButtonDown(0) && automaticFire == false)
        {
            if (BulletConunt > 0 && shootingOk == true && BulletConunt > -1 && isreloading == false)             //평소꺼
            {
                myaudio.Stop();
                myaudio.clip = arrAudio[0];
                myaudio.Play();

                shootingOk = false;


                laserT.GetComponent<laser>().laserOff();


                rb.gravityScale = 2f;
                ReturnScale();
                Invoke("GunCooltime", attackSpeed);
                scaleX = 0.84f; scaleY = 1.02f;

                transform.position += Vector3.left * 0.3f;
                shoot.GetComponent<Shoot>().Shooting();
                shake.GetComponent<Camera>().Shaking();
                reload.GetComponent<Gun>().Gunshoot();
                //bulletUI.GetComponent<BulletUI>().BulletCounting();
                GameObject Particle = Instantiate(ParticlePrefab_Bullet) as GameObject;
                Particle.transform.SetParent(this.transform, false);

                BulletConunt--;
            }
        }
        if (BulletConunt <= 0)
        {


            laserT.GetComponent<laser>().laserOff();

        }
        else
        {
            laserT.GetComponent<laser>().ResetA();
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
        if (collision.gameObject.tag == "xp")
        {
            XpUi.GetComponent<xpUi>().GetXp();
            if (xp < maxXp) 
            {
                myaudio.Stop();
                myaudio.clip = arrAudio[1];
                myaudio.Play();
            }
            
            xp++;
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

        dieUi.GetComponent<DieUi>().Hert();

        GameObject Particle = Instantiate(ParticlePrefab_Die) as GameObject;
        Particle.transform.SetParent(this.transform, false);
        shake.GetComponent<Camera>().superShaking();
        Time.timeScale = 1f;

        //transform.localScale = new Vector3(0.001f, 0.001f, -1f);
        scaleX = 0.001f;
        scaleY = 0.001f;
        Invoke("Result", 0.245f);
        Destroy(gameObject,0.25f);
    }
    void Result()
    {
        
        resultplayerpos = Mathf.Floor(transform.position.x);
        result.GetComponent<TitleAndRetry>().here();
    }
}
