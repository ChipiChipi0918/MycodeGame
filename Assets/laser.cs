using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color ObjColor;
    private bool hello = false;

    void Start()
    {
        
        objectRenderer = GetComponent<Renderer>();
        ObjColor = objectRenderer.material.color;
    }

    void Update()
    {
       
        
    }
    public void laserOff()
    {
        
            hello = true;
            Color transparentColor = ObjColor;
            transparentColor.a = 0.2f;
            objectRenderer.material.color = transparentColor;
            
        
    }

    public void ResetA()
    {
        
        objectRenderer.material.color = ObjColor;
        hello = false;
    }
}
