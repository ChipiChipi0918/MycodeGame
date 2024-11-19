using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    

    [SerializeField]
    private float bulletSpeed = 10f; // 속도 조절용

    private Rigidbody2D rb;
    private Vector2 direction;

    public GameObject ParticlePrefab_Bullet;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gameObject.tag = "Enemy";

        GameObject player = GameObject.Find("Player");
        
        Transform playerPos = player.transform;
        direction = (playerPos.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;

        Destroy(gameObject, 5f);
    }

    void Update()
    {

        


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "DeleteEnemy")
        {
            GameObject Particle = Instantiate(ParticlePrefab_Bullet,transform.position,transform.rotation);
            
            //gameObject.tag = "Notbullet";
            rb.velocity = Vector2.zero;
            Destroy(gameObject,0.12f);

        }
    }
}
