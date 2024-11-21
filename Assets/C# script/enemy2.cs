using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    public GameObject XpPrefab;
    public int enemyHP = 3;

    public float nuckbackAngle = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        if (enemyHP <= 0)
        {
            GameObject Xp = Instantiate(XpPrefab);
            Xp.transform.position = transform.position;
            Xp.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 13);
            Destroy(gameObject);

        }

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            transform.eulerAngles = new Vector3(0, 0, -1 * 20f);
            Invoke("nuckback", 0.1f);
            transform.position += new Vector3(3f, 0, 0);

            UnityEngine.Camera.main.GetComponent<Camera>().Shaking();
            enemyHP--;

        }
        if(collision.gameObject.tag == "DeleteEnemy")
        {
            Destroy(gameObject);
        }

    }
    void nuckback()
    {
        transform.eulerAngles = new Vector3(0, 0, 0f);
    }
}
