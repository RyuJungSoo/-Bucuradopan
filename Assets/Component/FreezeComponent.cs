using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezeComponent : MonoBehaviour
{
    private float curTime;
    public float skillTime = 7f; // 스킬 발동 시간
    public float coolTime = 30f; // Freeze 스킬 쿨타임

    public int SkillLevel = 0; // 스킬 레벨
    public bool isOn = false; // 스킬발동 여부



    public Image cool_skill; // 쿨타임 이미지
    public GameObject Effect_UI;
    public Image continue_skill; // 지속타임 이미지

    private GameObject[] monsters; // 몬스터 관리용 배열;


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
            //Debug.Log("쿨타임 안 찼음");
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
            //Debug.Log("쿨타임 안 찼음");
            curTime -= Time.deltaTime;
        }


    }





    IEnumerator CoolTime()
    {
        print("쿨타임 코루틴 실행");

        while (curTime >= 0)
        {
            cool_skill.fillAmount = (1.0f * (coolTime - curTime) / coolTime);
            yield return new WaitForFixedUpdate();
        }
        print("쿨타임 코루틴 완료");
        cool_skill.fillAmount = 0;
    }


    IEnumerator ContinueTime()
    {
        print("지속시간 코루틴 실행");

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

        print("지속시간 코루틴 완료");
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
