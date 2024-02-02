using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    
    // ����
    private float curTime;
    public float SpawnCoolTime = 1f; // ���� ��Ÿ��
    private int SpawnLevel;

    // �ԾϿ�����Ʈ �� ������Ʈ
    public Transform[] spawnPoint;
    private GameObject pool;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        pool = GameObject.Find("PoolManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (curTime <= 0)
        {
            Spawn(SpawnLevel);
            curTime = SpawnCoolTime;
        }
        else
            curTime -= Time.deltaTime;
    }


    void Spawn(int SpawnIndex)
    {
        if (!GameManager.instance.isGameOver)
        {
            GameObject enemy = pool.GetComponent<PoolManager>().monsterGet(SpawnIndex);
            enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position; // �ڽ� ������Ʈ�� ���õǵ��� ���� ������ 1����
        }
    }

    public void LevelUp()
    {
        SpawnLevel++;
    }
}
