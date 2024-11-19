using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieUi : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public float fadeDuration = 1.0f;
    public float displayTime = 0.01f;

    void Start()
    {

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f;
        }
    }

    public void Hert()
    {
        if (canvasGroup != null)
        {
            StopAllCoroutines();
            StartCoroutine(FadeInAndOut());
        }
    }
    private void Update()
    {
        
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
