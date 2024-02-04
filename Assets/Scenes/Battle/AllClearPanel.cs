using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AllClearPanel : MonoBehaviour
{
    private void Awake()
    {
        GameManager.instance.PlaySound(true, 3);
    }

    public void ChangeToEndingScene()
    {
        
        SceneManager.LoadScene("Ending");
    }
}
