using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    // 프리팹들을 보관할 변수
    public GameObject[] monsterPrefabs;

    // 풀 담당을 하는 리스트들
    public List<GameObject>[] monsterPools;

    // UI
    public GameObject canvas;
    private HpBarScript monsterHpUI;


    private void Awake()
    {
        // 몬스터 풀 리스트 배열 생성
        monsterPools = new List<GameObject>[monsterPrefabs.Length];
        for (int i = 0; i < monsterPools.Length; i++)
            monsterPools[i] = new List<GameObject>();

    }

    private void Start()
    {
        monsterHpUI = canvas.GetComponent<HpBarScript>();

    }

    public GameObject monsterGet(int index)
    {
        GameObject select = null;
        int curMonsterIndex = 0;
        // 선택한 풀의 놀고 (비활성화된) 있는 게임오브젝트 접근

        foreach (GameObject item in monsterPools[index])
        {
            if (!item.activeSelf)
            {
                // 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                select.GetComponent<MonsterComponent>().Object_ON();
                monsterHpUI.ActiveMonster(index, curMonsterIndex);
                break;
            }
            curMonsterIndex++;
        }

        if (select == null)
        {
            // 새롭게 생성하고 select 변수에 할당
            select = Instantiate(monsterPrefabs[index], transform);
            monsterPools[index].Add(select);
            monsterHpUI.AddMonster(index, select);
        }

        return select;
    }

}
