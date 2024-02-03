using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSystem : MonoBehaviour
{
    public GameObject skipPanel;
    public GameObject optionPanel;
   

    private void Awake()
    {
        skipPanel.SetActive(false);
        optionPanel.SetActive(false);
    }

    public void GameStart()
    {
        skipPanel.SetActive(true);
    }

    public void SkipTutorial(bool _bool)
    {
        if(_bool is true)
        {
            SceneManager.LoadScene("Battle");
        }
        else
        {
            SceneManager.LoadScene("Tutorial");
        }
    }

    public void Option()
    {
        optionPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
