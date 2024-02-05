using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StellaCheck : MonoBehaviour
{
    public Image[] Stella;

    private void Awake()
    {
        foreach(Image i in Stella)
        {
            i.gameObject.SetActive(false);
        }
    }

    public void UpdateStella()
    {
        int num = (int)GameManager.instance.stella;

        for(int i = 0; i<num; i++)
        {
            Stella[i].gameObject.SetActive(true);
        }
    }

}
