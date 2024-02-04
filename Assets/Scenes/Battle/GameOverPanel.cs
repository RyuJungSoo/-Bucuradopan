using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverPanel : MonoBehaviour
{
    public MouseController mouse;

    private void OnEnable()
    {
        mouse.GamePause = true;
        GameManager.instance.PlaySound(true, 2);
    }

    private void OnDisable()
    {
        mouse.GamePause = false;
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
