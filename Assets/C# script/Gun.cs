using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{

    public float reloadSpeed = 1000f;
    public bool reload = false;
    public float currentRotation = 0f; 

    public GameObject shoot;

    bool reloding = false;

    
    AudioSource myaudio;
    // Start is called before the first frame update
    void Start()
    {
        myaudio = this.GetComponent<AudioSource>();
    }
    public void Gunshoot()
    {
        if(reloding == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 7.558f);
            transform.localScale = new Vector3(2.58f, 2.81f, 2f);
            
            Invoke("BanDong",0.16f);
        }
        
    }
    void BanDong()
    {
        
            
            transform.eulerAngles = new Vector3(0, 0, 2.558f);
            transform.localScale = new Vector3(2.8f, 2.8f, 2f);
        
    }
    public void BulletReload()
    {
        myaudio.Play();
        reloding = true;
        reload = true;
        currentRotation = 0f;

        
        Invoke("EndReload", 0.8f);
    }
    // Update is called once per frame
    public void Update()
    {


        if (reload)
        {
            reloding = true;
            
            float rotationThisFrame = reloadSpeed * Time.deltaTime;
            currentRotation += rotationThisFrame;

            transform.Rotate(Vector3.forward * rotationThisFrame);
            if (currentRotation >= 360f)
            {
                
                reload = false;
                transform.eulerAngles = new Vector3(0, 0, 2.558f);
                
            }
        }
    }
    void EndReload()
    {
        
        shoot.GetComponent<Player>().ReloadingEnd();
    }
}
