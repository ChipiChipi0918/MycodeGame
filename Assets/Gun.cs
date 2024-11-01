using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{

    public float reloadSpeed = 1000f;
    public bool reload = false;
    public float currentRotation = 0f; // ���� ȸ�� ����
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void reloading()
    {
        transform.eulerAngles = new Vector3(0, 0, 7.558f);
        transform.localScale = new Vector3(2.58f, 2.81f, 2f);
        StartCoroutine("BanDong");
    }
    IEnumerator BanDong()
    {
        yield return new WaitForSeconds(0.16f);
        transform.eulerAngles = new Vector3(0, 0, 2.558f);
        transform.localScale = new Vector3(2.8f, 2.8f, 2f);

    }
    // Update is called once per frame
    public void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.R))
        {
            reload = true;
            currentRotation = 0f;
        }

        if (reload)
        {
            
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
}
