using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonEffectUi : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public float fadeDuration = 1.0f;
    public float displayTime = 0.01f;

    public Button btn;
    public int buttonCh = 0;
    void Start()
    {

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;
        }
        if(buttonCh == 1)
        {
            btn = GameObject.Find("Attack").GetComponent<Button>();
            btn.onClick.AddListener(Attack);
        }
        if (buttonCh == 2)
        {
            btn = GameObject.Find("AttackSpeed").GetComponent<Button>();
            btn.onClick.AddListener(AttackSpeed);
        }
        if (buttonCh == 3)
        {
            btn = GameObject.Find("BulletUp").GetComponent<Button>();
            btn.onClick.AddListener(BulletUp);
        }
        if (buttonCh == 4)
        {
            btn = GameObject.Find("Speed").GetComponent<Button>();
            btn.onClick.AddListener(Speed);
        }
    }

    
    private void Update()
    {
        
    }
    public void Attack()
    {
        if (canvasGroup != null)
        {
            StopAllCoroutines();
            StartCoroutine(FadeInAndOut());
        }
    }
    public void AttackSpeed()
    {
        if (canvasGroup != null)
        {
            StopAllCoroutines();
            StartCoroutine(FadeInAndOut());
        }
    }
    public void BulletUp()
    {
        if (canvasGroup != null)
        {
            StopAllCoroutines();
            StartCoroutine(FadeInAndOut());
        }
    }
    public void Speed()
    {
        if (canvasGroup != null)
        {
            StopAllCoroutines();
            StartCoroutine(FadeInAndOut());
        }
    }

    private IEnumerator FadeInAndOut()
    {

        yield return StartCoroutine(Fade(0f, 0.8f, 0.1f));


        yield return new WaitForSeconds(displayTime);


        yield return StartCoroutine(Fade(1f, 0f, fadeDuration));
    }

    private IEnumerator Fade(float start, float end, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, elapsedTime / duration);
            yield return null;
        }
        canvasGroup.alpha = end;
    }
}
