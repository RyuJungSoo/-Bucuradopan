using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingEvent : MonoBehaviour
{
    public Image[] image;
    public Image lastImage;

    public Image fadePanel;
    public float fadeDuration = 2.0f;

    public GameObject endingPanel;
    private void Awake()
    {        
        lastImage.gameObject.SetActive(false);

    }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float startTime = 0f;

        Color startColor = fadePanel.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (startTime < fadeDuration)
        {
            startTime += Time.deltaTime;

            float t = startTime / fadeDuration;
            fadePanel.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }

        fadePanel.color = targetColor;

        yield return ShowImage();

    }
    private IEnumerator ShowImage()
    {

        yield return new WaitForSeconds(2.0f);

        foreach (Image i in image)
        {
            yield return new WaitForSeconds(1.0f);

            i.gameObject.SetActive(false);
        }

        lastImage.gameObject.SetActive(true);

        yield return FadeOut();

    }
    private IEnumerator FadeOut()
    {
        float startTime = 0f;

        Color startColor = fadePanel.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (startTime < fadeDuration)
        {
            startTime += Time.deltaTime;

            float t = startTime / fadeDuration;
            fadePanel.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }

        fadePanel.color = targetColor;

        endingPanel.SetActive(true);
    }

    public void ChangeToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
