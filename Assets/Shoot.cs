using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 0.05f;
    public float BulletSpeed;
    public GameObject BulletPrefab;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject Bullet = Instantiate(BulletPrefab);
            Bullet.transform.position = transform.position;
            Bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * BulletSpeed); ;
        }
    }
}
