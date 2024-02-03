using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{

    public GameObject retryPanel;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        retryPanel.SetActive(true);
    }

    private void OnDisable()
    {
        retryPanel.SetActive(false);
    }
}
