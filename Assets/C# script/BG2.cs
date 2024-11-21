using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG2 : MonoBehaviour
{
    public GameObject bg1;
    private bool gay =true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void MoveBG2()
    {
        gay = true;
        gameObject.transform.position += new Vector3(55.74f, 0, 0);
    }
    // Update is called once per frame
    public void EnterBk2()
    {
        if (gay == true)
        {
            bg1.GetComponent<BG1>().MoveBG1();
            gay = false;
        }

        
    }
}
