using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public float jumpForce = 10f;
    private bool isGrounded = true;
    public int enemyHP = 3;

    public GameObject XpPrefab;
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
            transform.position += new Vector3(1.5f, 0.05f, 0);

            UnityEngine.Camera.main.GetComponent<Camera>().Shaking();
            enemyHP--;
            
        }
    }
}
