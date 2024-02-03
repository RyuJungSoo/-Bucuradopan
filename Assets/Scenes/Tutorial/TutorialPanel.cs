using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanel : MonoBehaviour
{
    public Image[] tutorialPanel;
    private int currentPage = 0;

    private void Awake()
    {
        foreach(Image i in tutorialPanel)
        {
            i.gameObject.SetActive(false);
        }

        tutorialPanel[0].gameObject.SetActive(true);
    }
    public void PrevButton()
    {
        if (currentPage > 0)
        {
            tutorialPanel[currentPage].gameObject.SetActive(false); // Hide the current panel
            currentPage--;
            tutorialPanel[currentPage].gameObject.SetActive(true); // Show the previous panel
        }
    }

    public void NextButton()
    {
        if (currentPage < tutorialPanel.Length - 1)
        {
            tutorialPanel[currentPage].gameObject.SetActive(false); // Hide the current panel
            currentPage++;
            tutorialPanel[currentPage].gameObject.SetActive(true); // Show the next panel
        }
    }
}
