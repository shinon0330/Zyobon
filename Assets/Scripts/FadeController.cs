using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public static FadeController Instance { get; private set; }

    [SerializeField] private Canvas fadeCanvas;
    [SerializeField] private Image fadeImage;
    [SerializeField] private float defaultFadeDuration = 1f;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        fadeCanvas.enabled = false;
    }

    public void FadeOut(float duration = 1f,Action onComplete = null)
    {
        float fadeDuration = duration > 0f ? duration : defaultFadeDuration;
        StartCoroutine(Fade(0f,1f, fadeDuration, onComplete));
    }

    public void FadeIn(float duration = 1f,Action onComplete = null)
    {
        float fadeDuration = duration > 0f ? duration : defaultFadeDuration;
        StartCoroutine(Fade(1f,0f, fadeDuration, onComplete));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha,float duration,
        Action onComplete)
    {
        fadeCanvas.enabled = true;

        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = endAlpha;
        fadeImage.color = color;

        if (endAlpha == 0f)
        {
            fadeCanvas.enabled = false;
        }

        onComplete?.Invoke();
    }
}
