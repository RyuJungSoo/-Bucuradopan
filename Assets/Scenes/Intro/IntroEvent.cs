using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

//Fade In -> ShowImage -> Fade Out -> ChangeScene
//위 순서로 코루틴이 진행됨.
//ChangeScene을 일반 함수로 만들었더니 잘 작동하지 않았음

public class IntroEvent : MonoBehaviour
{
    public Image[] image;

    public Image fadePanel;
    public float fadeDuration = 2.0f;
    private void Awake()
    {
        foreach(Image i in image)
        {
            i.gameObject.SetActive(false);
        }

        image[0].gameObject.SetActive(true);
    }
    void Start()
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
            i.gameObject.SetActive(true);

            yield return new WaitForSeconds(1.0f);

            i.gameObject.SetActive(false);
        }

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
            
            float t = startTime/fadeDuration;
            fadePanel.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }

        fadePanel.color = targetColor;
        
        yield return ChangeScene();
    }
    private IEnumerator ChangeScene()
    {
        SceneManager.LoadScene("Battle");

        yield return null;
    }

}
