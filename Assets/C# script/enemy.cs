using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public float jumpForce = 10f;
    private bool isGrounded = true;
    public float enemyHP = 3;

    public float nuckbackAngle = 20;

    public GameObject XpPrefab;

    public int enemyXp = 1;
    public GameObject ParticlePrefab_EnemyDie;

    public Player player;

    //public Player palyer;
    private void Start()
    {
        
        player = GameObject.Find("Player").GetComponent<Player>();
        
    }
    void Update()
    {
        
        if (enemyHP <= 0)
        {
            GameObject Particle = Instantiate(ParticlePrefab_EnemyDie, transform.position, transform.rotation);
            for (int i = 0; i < enemyXp; i++)
            {
                
                GameObject Xp = Instantiate(XpPrefab, transform.position, transform.rotation);

                Xp.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Random.Range(8, 14));
            }


            Destroy(gameObject);

        }
        
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.contacts[0].normal.y > 0.5f)
        {

            isGrounded = true;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            transform.eulerAngles = new Vector3(0, 0, -1*20f);
            
            transform.position += new Vector3(1.5f, 0.05f, 0);

            UnityEngine.Camera.main.GetComponent<Camera>().Shaking();
            enemyHP -= player.damage;
            Invoke("nuckback", 0.1f);
        }
        if (collision.gameObject.tag == "DeleteEnemy")
        {
            Destroy(gameObject);
        }
    }
    void nuckback()
    {
        transform.eulerAngles = new Vector3(0, 0, 0f);
    }
}
