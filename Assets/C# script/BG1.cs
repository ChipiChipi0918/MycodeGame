using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG1 : MonoBehaviour
{
    public GameObject bg2;
    private bool gay = true;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    public void MoveBG1()
    {
        gay = true;
        gameObject.transform.position += new Vector3(55.74f, 0, 0);
    }
    // Update is called once per frame
    public void EnterBk1()
    {
        if(gay == true)
        {
            bg2.GetComponent<BG2>().MoveBG2();
            gay = false;
        }
        
    }
    
    
}
