using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingSkillComponent : MonoBehaviour
{
    private float curTime;
    public float coolTime = 20f; // King ��ų ��Ÿ��
    public int SkillLevel = 0; // ��ų ����
    public float Damage = 20f; // ���� �ӵ���

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
            if (Input.GetKey(KeyCode.Alpha2))
            {
                GameManager.instance.PlaySound(false, 3);
                Effect_UI.SetActive(true);
                monsters = GameObject.FindGameObjectsWithTag("Monster");
                foreach (GameObject monster in monsters)
                {
                    
                    monster.GetComponent<MonsterComponent>().TakeDamage(Damage + 0.1f*SkillLevel);
                    
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
