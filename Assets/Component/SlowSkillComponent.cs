using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowSkillComponent : MonoBehaviour
{
    private float curTime;
    public float coolTime = 10f; // Slow ��ų ��Ÿ��
    public int SkillLevel = 0; // ��ų ����
    public float Debuff_speed = 1f; // ���� �ӵ���

    public Image cool_skill; // ��Ÿ�� �̹���
    public GameObject Effect_UI;
    private GameObject[] monsters; // ���� ������ �迭;

    // Start is called before the first frame update
    void Start()
    {
        this.SkillLevel = SkillLevel;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (curTime > 0)
        {
            //Debug.Log("��Ÿ�� �� á��");
            curTime -= Time.deltaTime;
        }
        Skill();
    }

    public void LevelUp()
    {
        SkillLevel += 1;
    }

    private void Skill()
    {
        if (curTime <= 0 && GameManager.instance.isGameOver == false)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                Effect_UI.SetActive(true);
                monsters = GameObject.FindGameObjectsWithTag("Monster");
                foreach (GameObject monster in monsters)
                {
                    if (monster.GetComponent<MonsterComponent>().isSlow == false)
                    {
                        monster.GetComponent<MonsterComponent>().isSlow = true;
                        monster.GetComponent<MonsterComponent>().speed -= (Debuff_speed + 0.2f*SkillLevel);

                        if (monster.GetComponent<MonsterComponent>().speed <= 0)
                            monster.GetComponent<MonsterComponent>().speed = 0.5f;

                    }
                }

                curTime = coolTime;
                StartCoroutine(CoolTime(coolTime));
            }
        }
    
    }


    IEnumerator CoolTime(float cool)
    {
        print("��Ÿ�� �ڷ�ƾ ����");

        while (cool >= 0)
        {
            cool -= Time.deltaTime;
            cool_skill.fillAmount = (1.0f * (coolTime - cool) / coolTime);
            yield return new WaitForFixedUpdate();
        }
        print("��Ÿ�� �ڷ�ƾ �Ϸ�");
        cool_skill.fillAmount = 0;
    }
}
