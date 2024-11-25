using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiled : MonoBehaviour
{
    public GameObject ParticlePrefab_Shiled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            
        
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Sawblade")
        {

            GameObject Particle = Instantiate(ParticlePrefab_Shiled, transform.position, transform.rotation);
            Destroy(gameObject,0.5f);
        }
    }
    
}
