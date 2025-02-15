using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    
    // 변수
    private float curTime;
    public float SpawnCoolTime = 1f; // 스폰 쿨타임
    public int SpawnLevel;

    // 게암오브젝트 및 컴포넌트
    public Transform[] spawnPoint;
    public GameObject[] Boss;
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
            Spawn(Random.Range(0,SpawnLevel +1));
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

    public void BossSpawn()
    {
        

        if (!GameManager.instance.isGameOver)
        {
            GameObject enemy = Boss[SpawnLevel];
            enemy.SetActive(true);
            enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position; // 자식 오브젝트만 선택되도록 랜덤 시작은 1부터
            
        }

    }

    public float Cur_BossHp()
    {
        
        return Boss[SpawnLevel].GetComponent<MonsterComponent>().Hp;
    }

    public float Cur_BossMaxHp()
    {

        return Boss[SpawnLevel].GetComponent<MonsterComponent>().maxHp;
    }

    public void LevelUp()
    {
        SpawnLevel++;
    }

    public void AllKill()
    {
        MonsterComponent[] allChildren = pool.GetComponentsInChildren<MonsterComponent>();
        bool isFlag = false; // 처음에 어미부터 확인하는거 체크용 flag
        foreach (MonsterComponent child in allChildren)
        {
            if (isFlag == false)
            {
                isFlag = true;
                continue;
            }
            Debug.Log(child.gameObject.name);
            child.TakeDamage(child.maxHp);
        
        }
    
    
    }
}
