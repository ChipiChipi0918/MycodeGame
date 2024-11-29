using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleAndRetry : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
         gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void here()
    {
        Invoke("Result",0.5f);
        
    }
    void Result()
    {
        gameObject.SetActive(true);
    }
    public void Title()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1f;
    }
    public void Retry()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
}
