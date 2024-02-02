using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    
    // 변수
    private float curTime;
    public float SpawnCoolTime = 1f; // 스폰 쿨타임
    private int SpawnLevel;

    // 게암오브젝트 및 컴포넌트
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
            enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position; // 자식 오브젝트만 선택되도록 랜덤 시작은 1부터
        }
    }

    public void LevelUp()
    {
        SpawnLevel++;
    }
}
