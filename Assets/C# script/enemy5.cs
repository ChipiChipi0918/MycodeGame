using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.BoolParameter;

public class enemy5 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    public GameObject XpPrefab;
    public float enemyHP = 3;

    public float nuckbackAngle = 20;

    public int enemyXp = 2;
    public GameObject ParticlePrefab_EnemyDie;

    [SerializeField]
    private float chaseSpeed = 10f;

    public Player player;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        Detect();
    }

    // Update is called once per frame

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


        
    }
    
    void Detect()
    {
        GameObject player = GameObject.Find("Player");
        Transform playerPos = player.transform;
        direction = (playerPos.position - transform.position).normalized;

        rb.velocity = direction * chaseSpeed;
        Invoke("DetectStop",0.3f);
    }
    void DetectStop()
    {
        rb.velocity = Vector2.zero;
        Invoke("Detect", 0.2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            transform.eulerAngles = new Vector3(0, 0, -1 * 20f);

            transform.position += new Vector3(3f, 0, 0);

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
