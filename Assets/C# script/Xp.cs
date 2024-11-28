using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp : MonoBehaviour
{
    public GameObject targetPosition;
    AudioSource myaudio;
    // Start is called before the first frame update
    void Start()
    {
        myaudio = this.GetComponent<AudioSource>();
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
            myaudio.Play();
            Destroy(gameObject);
        }
    }


}
