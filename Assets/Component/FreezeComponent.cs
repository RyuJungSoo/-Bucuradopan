using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezeComponent : MonoBehaviour
{
    private float curTime;
    public float skillTime = 7f; // ��ų �ߵ� �ð�
    public float coolTime = 30f; // Freeze ��ų ��Ÿ��

    public int SkillLevel = 0; // ��ų ����
    public bool isOn = false; // ��ų�ߵ� ����



    public Image cool_skill; // ��Ÿ�� �̹���
    public GameObject Effect_UI;
    public Image continue_skill; // ����Ÿ�� �̹���

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
        skillTime += 0.5f;

    }

    public void Skill()
    {
        if (curTime <= 0 && GameManager.instance.isGameOver == false)
        {


            if (Input.GetKey(KeyCode.Alpha3) && isOn == false)
            {
                GameManager.instance.PlaySound(false, 2);
                Effect_UI.SetActive(true);
                monsters = GameObject.FindGameObjectsWithTag("Monster");
                foreach (GameObject monster in monsters)
                {
                    
                    monster.GetComponent<MonsterComponent>().Freeze();
                    
                }
                isOn = true;
                curTime = skillTime;
                StartCoroutine(ContinueTime());
            }



        }

        else
        {
            //Debug.Log("��Ÿ�� �� á��");
            curTime -= Time.deltaTime;
        }


    }





    IEnumerator CoolTime()
    {
        print("��Ÿ�� �ڷ�ƾ ����");

        while (curTime >= 0)
        {
            cool_skill.fillAmount = (1.0f * (coolTime - curTime) / coolTime);
            yield return new WaitForFixedUpdate();
        }
        print("��Ÿ�� �ڷ�ƾ �Ϸ�");
        cool_skill.fillAmount = 0;
    }


    IEnumerator ContinueTime()
    {
        print("���ӽð� �ڷ�ƾ ����");

        while (curTime >= 0)
        {

            continue_skill.fillAmount = (1.0f * (skillTime - curTime) / skillTime);
            yield return new WaitForFixedUpdate();
        }

        foreach (GameObject monster in monsters)
        {

            //Debug.Log(collider.tag);
            monster.GetComponent<MonsterComponent>().FreezeEnd();
            
        }

        print("���ӽð� �ڷ�ƾ �Ϸ�");
        Effect_UI.SetActive(false);
        continue_skill.fillAmount = 0;

        if (isOn == true)
        {
            isOn = false;
            curTime = coolTime;
            StartCoroutine(CoolTime());
        }

    }
}
