using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverPanel : MonoBehaviour
{
    public GameObject retryPanel;

    private void Awake()
    {
        //retryPanel.SetActive(false);
        GameManager.instance.PlaySound(true, 2);
    }

    private IEnumerator ShowRetryPanel()
    {
        yield return new WaitForSeconds(5f);

        retryPanel.SetActive(true);

        yield return null;
    }

    private void OnEnable()
    {
        StartCoroutine(ShowRetryPanel());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        retryPanel.SetActive(false);
    }

    public void Retry()
    {
        GameManager.instance.Retry();
    }

    public void GiveUp()
    {
        GameManager.instance.soundManager.GetComponent<SoundManager>().DestroySoundManager();
        SceneManager.LoadScene("MainMenu");
    }
}
