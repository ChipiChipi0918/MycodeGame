using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp : MonoBehaviour
{
    public GameObject targetPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition.transform.position, 0.1f);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            Destroy(gameObject, 3f);

        }
        if (collision.gameObject.tag == "Player")
        {
            
            Destroy(gameObject);
        }
    }


}
