using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.BoolParameter;

public class enemy7 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    public GameObject XpPrefab;
    public float enemyHP = 5;

    public float rotationSpeed = 50f;

    public int enemyXp = 3;
    public GameObject ParticlePrefab_EnemyDie;
    public GameObject wolfDash;
    public Player player;

    private Animator Anim;

    private float timeAfterAttack = 0;
    public float attactRate = 4f;

    public bool isAttack = false;

    public GameObject shake;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
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

        timeAfterAttack += Time.deltaTime;

        if (timeAfterAttack >= attactRate)
        {
            timeAfterAttack = 0f;
            
            isAttack = true;
            Invoke("dd", 0.7f);
            Anim.SetBool("IsAttack", true);
            Debug.Log("d");
            
        }
        else
        {
            
            Anim.SetBool("IsAttack", false);
        }
    }
    void dd()
    {
        GameObject Particle = Instantiate(wolfDash, transform.position, transform.rotation);
        shake.GetComponent<Camera>().Shaking();
        transform.position += new Vector3(-5f, 0, 0);
        isAttack = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            if (isAttack == true)
            {
                transform.position += new Vector3(3f, 0, 0);
            }
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
