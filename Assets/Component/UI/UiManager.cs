using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    //�̺�Ʈ �� UI �г�
    public GameObject deathPanel;
    public GameObject allClearPanel;
    public GameObject waveClearPanel;
    public Image Hp_Bar;

    public static UiManager instance = null;

    private void Awake()
    {
        //deathPanel.SetActive(false);
        //allClearPanel.SetActive(false);
        //waveClearPanel.SetActive(false);

        if (instance == null)
        {
            instance = this;

        }

        else
            Destroy(this.gameObject);

    }

    public void HpBarUpdate()
    {
        Hp_Bar.fillAmount = GameManager.instance.magicCircle.Hp / GameManager.instance.magicCircle.maxHp;

    }
}
