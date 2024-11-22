using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy4 : MonoBehaviour
{
    public float moveSpeed = 0f;
    private Rigidbody2D rb;

    public GameObject XpPrefab;
    public int enemyHP = 5;

    private Animator Anim;

    public float attactRate = 4f;
    private Transform target;
    private float timeAfterAttack = 0;

    public float nuckbackAngle = 20;

    public int enemyXp = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        if (enemyHP <= 0)
        {
            for (int i = 0; i < enemyXp; i++)
            {
                
                GameObject Xp = Instantiate(XpPrefab,transform.position,transform.rotation);
                
                Xp.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Random.Range(8,14));
            }
            
            Destroy(gameObject);

        }

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;


        timeAfterAttack += Time.deltaTime;

        if (timeAfterAttack >= attactRate)
        { 
            timeAfterAttack = 0f;

            Anim.SetBool("snakeisAttack", true);
            Debug.Log("d");
        }
        else
        {
            Anim.SetBool("snakeisAttack", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            transform.eulerAngles = new Vector3(0, 0, -1 * 20f);
            Invoke("nuckback", 0.1f);
            transform.position += new Vector3(0.3f, 0, 0);

            UnityEngine.Camera.main.GetComponent<Camera>().Shaking();
            enemyHP--;

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
