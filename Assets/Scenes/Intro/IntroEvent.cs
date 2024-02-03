using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroEvent : MonoBehaviour
{
    public Image[] image;

    public Image fadePanel;
    public float fadeDuration = 1.0f;
    private void Awake()
    {
        foreach(Image i in image)
        {
            i.gameObject.SetActive(false);
        }
        
        fadePanel.gameObject.SetActive(false);
    }
    void Start()
    {
        StartCoroutine(ShowImage());
    }


    public void ChangeScene()
    {
        SceneManager.LoadScene("Battle");
    }
    
    private IEnumerator FadeIn()
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
        
        ChangeScene();
    }
    private IEnumerator ShowImage()
    {

        foreach(Image i in image)
        {
            i.gameObject.SetActive(true);

            yield return new WaitForSeconds(1.0f);

            i.gameObject.SetActive(false);
        }

        yield return FadeIn();

    }

}
