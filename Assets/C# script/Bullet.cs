using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Bullet : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float range = 0.6f;
    public GameObject ParticlePrefab_Bullet;
    private Rigidbody2D rb;
    public GameObject Trail;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "bullet";
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Invoke("Destory", range);   
    }

    // Update is called once per frame

    private void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Color color = spriteRenderer.color;
            color.a = 0f;
            spriteRenderer.color = color;
            Trail.GetComponent<DestroyTrail>().Destroy();

            GameObject Particle = Instantiate(ParticlePrefab_Bullet) as GameObject;
            Particle.transform.SetParent(this.transform, false);
            Invoke("tag", 0.01f);
            rb.velocity = Vector2.zero;

            Destroy(gameObject,0.32f);
        }
    }
    void tag()
    {
        gameObject.tag = "Notbullet";
    }
}
