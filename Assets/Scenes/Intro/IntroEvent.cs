using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

//Fade In -> ShowImage -> Fade Out -> ChangeScene
//위 순서로 코루틴이 진행됨.
//ChangeScene을 일반 함수로 만들었더니 잘 작동하지 않았음

public class IntroEvent : MonoBehaviour
{
    public Image[] image;
    public Image lastImage;

    public Image fadePanel;
    public Image skipPanel;

    public float fadeDuration = 2.0f;

    private bool isSkip = false;

    private void Awake()
    {
        skipPanel.gameObject.SetActive(false);
    }

    void Start()
    {
        FadeScene();
    }
    public void FadeScene()
    {
        StopAllCoroutines();
        StartCoroutine(Fade());

    }

    public void IsSkip()
    {
        isSkip = true;
    }
    private IEnumerator Fade()
    {
        if (isSkip is false) {

            yield return FadeIn();

            yield return ShowImage();

        }

        yield return FadeOut();

        yield return ChangeScene();

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

        fadePanel.gameObject.SetActive(false);

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

    }
    private IEnumerator FadeOut()
    {
        fadePanel.gameObject.SetActive(true);

        Time.timeScale = 1f;

        float startTime = 0f;
        
        Color startColor = fadePanel.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (startTime < fadeDuration)
        {
            startTime += Time.deltaTime;
            
            float t = startTime/fadeDuration;
            fadePanel.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }

        fadePanel.color = targetColor;        

    }

    private IEnumerator ChangeScene()
    {
        yield return null;

        SceneManager.LoadScene("Battle");

    }

}
