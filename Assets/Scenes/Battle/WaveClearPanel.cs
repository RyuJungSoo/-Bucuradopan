using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveClearPanel : MonoBehaviour
{
    public TMP_Text firstText;
    public TMP_Text secondText;
    public TMP_Text thirdText;

    public MouseController mouse;
    public SpawnComponent spawnComponent;

    private void Update()
    {
        firstText.text =
            "���ݷ�" + GameManager.instance.atk.ToString() + " -> " + (GameManager.instance.atk + 1).ToString()
            ;
        secondText.text =
            "���¹̳�" + GameManager.instance.stamina_usage.ToString() + " -> " + (GameManager.instance.stamina_usage - 1).ToString()
            + "\n(���¹̳� ȸ���� 1.5�� ����)"
            ;
        thirdText.text =
            "HP" + GameManager.instance.magicCircle.maxHp.ToString() + " -> " + (GameManager.instance.magicCircle.maxHp * 3).ToString()
            + "\n(Hp ��ü ȸ��)"
            ;
    }

    private void OnEnable()
    {
        spawnComponent.AllKill();
        Time.timeScale = 0f;
        mouse.GamePause = true;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
        mouse.GamePause = false;
    }

    public void IncreaseStellaPoint()
    {
        GameManager.instance.stella += 1f;
    }
    public void IncreaseAtk()
    {
        GameManager.instance.atk += 1f;
    }

    public void ReduceStaminaUsage()
    {
        GameManager.instance.stamina_usage -= 1f;
        GameManager.instance.stamina_RecoverSpeed *= 1.5f;
    }

    public void IncreaseHP()
    {
        GameManager.instance.magicCircle.maxHp *=3f;
        GameManager.instance.magicCircle.Hp = GameManager.instance.magicCircle.maxHp;

        UiManager.instance.HpBarUpdate();

    }

}
