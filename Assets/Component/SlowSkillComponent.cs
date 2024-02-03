using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowSkillComponent : MonoBehaviour
{
    private float curTime;
    public float coolTime = 10f; // Slow 스킬 쿨타임
    public int SkillLevel = 0; // 스킬 레벨
    public float Debuff_speed = 1f; // 깎을 속도값

    public Image cool_skill; // 쿨타임 이미지
    public GameObject Effect_UI;
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
        print("쿨타임 코루틴 실행");

        while (cool >= 0)
        {
            cool -= Time.deltaTime;
            cool_skill.fillAmount = (1.0f * (coolTime - cool) / coolTime);
            yield return new WaitForFixedUpdate();
        }
        print("쿨타임 코루틴 완료");
        cool_skill.fillAmount = 0;
    }
}
