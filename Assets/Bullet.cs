using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destory", 2f);   
    }

    // Update is called once per frame
    void Destory()
    {
        Destroy(gameObject);
    }
}
