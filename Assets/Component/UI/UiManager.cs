using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    //이벤트 별 UI 패널
    public GameObject deathPanel;
    public GameObject allClearPanel;
    public GameObject waveClearPanel;
    public Image Hp_Bar;
    public Image Stamina_Bar;
    public Image Progress_Bar;

    public GameObject BossHpBar_Object;
    public Image BossHp_Bar;

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

    public void StaminaBarUpdate()
    {
        Stamina_Bar.fillAmount = GameManager.instance.Stamina / GameManager.instance.maxStamina;

    }

    public void BossHpBar_ON()
    {
        BossHpBar_Object.SetActive(true);
        SpawnComponent spawnComponent = GameManager.instance.Spawner.GetComponent<SpawnComponent>();
        BossHp_Bar.fillAmount = 1;
    }

    public void BossHpBar_OFF()
    {
        BossHpBar_Object.SetActive(false);
    }

    public void BossHpBar_Update()
    {

        SpawnComponent spawnComponent = GameManager.instance.Spawner.GetComponent<SpawnComponent>();
        BossHp_Bar.fillAmount = spawnComponent.Cur_BossHp() / spawnComponent.Cur_BossMaxHp();
    }

    public void ProgressBarUpdate()
    {
        Progress_Bar.fillAmount = GameManager.instance.Progress / GameManager.instance.max_Progress;

    }
}
