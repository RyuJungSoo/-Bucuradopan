using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{

    //이벤트 별 UI 패널
    public GameObject deathPanel;
    public GameObject allClearPanel;
    public GameObject waveClearPanel;

    public Image Hp_Bar;
    public TMP_Text Hp_Data;
    public Image Stamina_Bar;
    public TMP_Text Stamina_Data;
    public Image Progress_Bar;
    public TMP_Text Progress_Data;

    public GameObject BossHpBar_Object;
    public Image BossHp_Bar;
    public TMP_Text BossHp_Data;

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

    public void EnableGameOverPanel()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DisableGameOverPanel()
    {
        deathPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void EnableAllClearPanel()
    {
        allClearPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DisableAllClearPanel()
    {
        allClearPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void EnableClearPanel()
    {
        waveClearPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DisableClearPanel()
    {
        waveClearPanel.SetActive(false);
        Time.timeScale = 1f;
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


    public void HpBarUpdate()
    {
        float Max_Hp = GameManager.instance.magicCircle.maxHp;
        float Current_Hp = GameManager.instance.magicCircle.Hp;

        Hp_Bar.fillAmount = Current_Hp / Max_Hp;
        Hp_Data.text = Current_Hp.ToString("F0") + $" / {Max_Hp}";

    }

    public void StaminaBarUpdate()
    {
        float Max_Stamina = GameManager.instance.maxStamina;
        float Current_Stamina = GameManager.instance.Stamina; 

        Stamina_Bar.fillAmount = Current_Stamina / Max_Stamina;
        Stamina_Data.text = Current_Stamina.ToString("F0") + $" / {Max_Stamina}";
    }
    public void ProgressBarUpdate()
    {
        float Max_progress = GameManager.instance.max_Progress;
        float Current_Progress = GameManager.instance.Progress;

        Progress_Bar.fillAmount = Current_Progress / Max_progress;
        Progress_Data.text = (Current_Progress / Max_progress * 100f).ToString("F1") + "%";

    }
    public void BossHpBar_Update()
    {
        SpawnComponent spawnComponent = GameManager.instance.Spawner.GetComponent<SpawnComponent>();

        float Boss_MaxHp = spawnComponent.Cur_BossMaxHp();
        float Boss_CurrentHp = spawnComponent.Cur_BossHp();

        BossHp_Bar.fillAmount = Boss_CurrentHp / Boss_MaxHp;
        BossHp_Data.text = $"{Boss_CurrentHp} / {Boss_MaxHp}";

    }

}
