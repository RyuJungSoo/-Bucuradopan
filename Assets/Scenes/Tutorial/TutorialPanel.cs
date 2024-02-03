using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Image[] tutorialPanel;
    private int currentPage = 0;

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
