using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.BoolParameter;

public class enemy6 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    public GameObject XpPrefab;
    public float enemyHP = 5;

    public float rotationSpeed = 50f;

    public int enemyXp = 3;
    public GameObject ParticlePrefab_EnemyDie;

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
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

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        Vector3 rotation = transform.eulerAngles;
        rotation.z += rotationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            transform.eulerAngles = new Vector3(0, 0, -1 * 20f);
            UnityEngine.Camera.main.GetComponent<Camera>().Shaking();
            enemyHP -= player.damage;
            
        }
        if (collision.gameObject.tag == "DeleteEnemy")
        {
            Destroy(gameObject);
        }

    }
    
}
