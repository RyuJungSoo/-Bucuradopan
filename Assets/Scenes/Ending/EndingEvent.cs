using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingEvent : MonoBehaviour
{
    public Image[] image;
    public Image lastImage;

    public GameObject endingPanel;
    private void Awake()
    {
        foreach(Image i in image)
        {
            i.gameObject.SetActive(false);
        }
        
        lastImage.gameObject.SetActive(false);

        endingPanel.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(ShowImage());
    }

    private IEnumerator ShowImage()
    {

        foreach(Image i in image)
        {
            i.gameObject.SetActive(true);

            yield return new WaitForSeconds(1.0f);

            i.gameObject.SetActive(false);
        }
        
        lastImage.gameObject.SetActive(true);

        yield return new WaitForSeconds(3.0f);
        
        endingPanel.SetActive(true);

        yield return null;
    }
}
