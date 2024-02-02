using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterComponent : MonoBehaviour
{
    // 스탯
    public float speed = 1f;
    public float Hp = 20;
    public float maxHp = 20;
    public float Damage = 2;

    // 변수
    public bool isDead = false;
    public bool isFreeze = false;
    public bool isAttack = false;
    public bool isAttacked = false;

    // 게암오브젝트 및 컴포넌트
    public GameObject magicCircle;
    private Rigidbody2D monsterRig;


    // Start is called before the first frame update
    void Awake()
    {
        monsterRig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (magicCircle.active == false)
            return;
   

        if (isDead == false && isFreeze == false)
        {
            Move();
        }
    
    }

    private void Object_OFF()
    {
        //Destroy(this.gameObject);
        gameObject.SetActive(false);
    }

    public void Object_ON()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<Collider2D>().enabled = true;
        Hp = maxHp;
        isDead = false;
        isAttacked = false;
        isFreeze = false;
    }

    private void Move()
    {
        // 스프라이트 정면 바꾸기
        float Abs_x = Mathf.Abs(transform.localScale.x);
        float Abs_y = Mathf.Abs(transform.localScale.y);

        if (transform.position.x <= magicCircle.transform.position.x)
            transform.localScale = new Vector2(1 * Abs_x, 1 * Abs_y);
        else
            transform.localScale = new Vector2(-1 * Abs_x, 1 * Abs_y);

        // 이동
        Vector2 dirVec = magicCircle.GetComponent<Rigidbody2D>().position - monsterRig.position; // Rigidbody2D 중심 기준으로 방향 계산
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        monsterRig.MovePosition(monsterRig.position + nextVec);
    }

    public void TakeDamage(float damage)
    {
        isAttacked = true;
        Hp -= damage;
        if (Hp <= 0)
        {
            monsterRig.velocity = new Vector3(0, 0); // 관성 지우기
            isDead = true;
            GetComponent<Collider2D>().enabled = false;
            Object_OFF();

        }
        isAttacked = false;

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("magicCircle") && isFreeze == false)
        {
            collision.gameObject.GetComponent<magicCircleComponent>().TakeDamage(Time.deltaTime * Damage);
        }
    }
}
