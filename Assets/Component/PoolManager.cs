using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    // �����յ��� ������ ����
    public GameObject[] monsterPrefabs;

    // Ǯ ����� �ϴ� ����Ʈ��
    public List<GameObject>[] monsterPools;

    // UI
    public GameObject canvas;
    private HpBarScript monsterHpUI;


    private void Awake()
    {
        // ���� Ǯ ����Ʈ �迭 ����
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
        // ������ Ǯ�� ��� (��Ȱ��ȭ��) �ִ� ���ӿ�����Ʈ ����

        foreach (GameObject item in monsterPools[index])
        {
            if (!item.activeSelf)
            {
                // �߰��ϸ� select ������ �Ҵ�
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
            // ���Ӱ� �����ϰ� select ������ �Ҵ�
            select = Instantiate(monsterPrefabs[index], transform);
            monsterPools[index].Add(select);
            monsterHpUI.AddMonster(index, select);
        }

        return select;
    }

}
