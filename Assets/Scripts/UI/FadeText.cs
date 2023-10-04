using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    [SerializeField] float duration;
    //int red;
    //int green;
    //int blue;

    private void Start()
    {
        //If no duration is set, set default duration
        if(duration == 0)
        {
            duration = 1;
        }
        //red = Mathf.RoundToInt(text.color.r);
        //green = Mathf.RoundToInt(text.color.g);
        //blue = Mathf.RoundToInt(text.color.b);
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public void StartDarken()
    {
        StartCoroutine(Darken());
    }

    public void StartLighten()
    {
        StartCoroutine(Lighten());
    }

    public void StartRestartDarken()
    {
        StartCoroutine(RestartDarken());
    }


    public IEnumerator Darken()
    {
        Image plane = GetComponent<Image>();
        Color originalColor = new Color(0, 0, 0, 0.7f);
        for (float t = 0.01f; t < duration; t += Time.deltaTime)
        {
            plane.color = Color.Lerp(Color.clear, originalColor, Mathf.Min(1, t / duration));
            yield return null;
        }
    }

    public IEnumerator Lighten()
    {
        Image plane = GetComponent<Image>();
        Color originalColor = new Color(0, 0, 0, 0.7f);
        for (float t = 0.01f; t < duration; t += Time.deltaTime)
        {
            plane.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / duration));
            yield return null;
        }
    }

    public IEnumerator RestartDarken()
    {
        Image plane = GetComponent<Image>();
        Color originalColor = new Color(0, 0, 0, 1.0f);
        for(float t = 0.01f; t < duration; t += Time.deltaTime)
        {
            plane.color = Color.Lerp(Color.clear, originalColor, Mathf.Min(1, t / duration));
        }
                for (float t = 0.01f; t < duration; t += Time.deltaTime)
        {
            plane.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / duration));
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        Text text = GetComponent<Text>();
        for (float t = 0.01f; t < duration; t += Time.deltaTime)
        {
            text.color = Color.Lerp(new Color(1, 1, 1), Color.clear, Mathf.Min(1, t / duration));
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        Text text = GetComponent<Text>();
        text.color = Color.clear;
        for (float t = 0.01f; t < duration; t += Time.deltaTime)
        {
            text.color = Color.Lerp(Color.clear, new Color(1, 1, 1), Mathf.Min(1, t / duration));
            yield return null;
        }
    }
}
