using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.BoolParameter;

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
        StopAllCoroutines();
        StartCoroutine(Corou());
    }
    IEnumerator Corou()
    {
        Time.timeScale = 1f;
        new WaitForSeconds(0.3f);
        Time.timeScale = 0.5f;
        new WaitForSeconds(0.3f);
        Time.timeScale = 0;
        yield return 0;
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
