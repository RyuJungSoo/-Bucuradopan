using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowSkillInformation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 scaleIncrease = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 originalScale;

    private float _waitingTime = 0.5f;

    public Image skillPanel;

    private void Awake()
    {
        skillPanel.gameObject.SetActive(false);  
    }

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entered");
        transform.localScale = originalScale + scaleIncrease;

        StartCoroutine(CountTime());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exited");
        transform.localScale = originalScale;

        StopAllCoroutines();
        skillPanel.gameObject.SetActive(false);
    }

    private IEnumerator CountTime()
    {
        float currentTime = 0f;

        while(currentTime < _waitingTime)
        {
            currentTime += Time.deltaTime;
        }

        skillPanel.gameObject.SetActive(true);

        yield return null;
    }

}