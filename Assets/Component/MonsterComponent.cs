using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterComponent : MonoBehaviour
{
    // ����
    public float speed = 1f;
    public float Hp = 20;
    public float maxHp = 20;
    public float Damage = 2;
    private float Prev_Speed;

    // ����
    public bool isDead = false;
    public bool isFreeze = false;
    public bool isAttack = false;
    public bool isAttacked = false;
    public bool isSingleton = false;
    public bool isSlow = false; // Slow ����� ����
    private float tmp_mass;

    // �ԾϿ�����Ʈ �� ������Ʈ
    private GameObject magicCircle;
    private Rigidbody2D monsterRig;
    private Animator animator;
    private Renderer monsterRenderer;


    private void OnEnable()
    {
        if (isSingleton)
            UiManager.instance.BossHpBar_ON();
    }

    // Start is called before the first frame update
    void Awake()
    {
        monsterRenderer = GetComponent<Renderer>();
        monsterRig = GetComponent<Rigidbody2D>();
        magicCircle = GameObject.Find("magicCircle");
        animator = GetComponent<Animator>();
        Prev_Speed = speed;
        tmp_mass = this.gameObject.GetComponent<Rigidbody2D>().mass;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // magicCircle�� ��Ȱ��ȭ�Ǿ��ְų� �Ҵ���� ������ ���
        if (magicCircle == null || magicCircle.active == false)
            return;

        float distance = Vector2.Distance(transform.position, magicCircle.transform.position);
        if (isDead == false && isFreeze == false)
        {
            Move(distance);
        }
        else
            animator.SetBool("isWalk", false);

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
        isSlow = false;
        this.speed = Prev_Speed;
        FreezeEnd();

    }

    private void Move(float distance)
    {

        if(distance > 0)
            animator.SetBool("isWalk", true);

        // ��������Ʈ ���� �ٲٱ�
        float Abs_x = Mathf.Abs(transform.localScale.x);
        float Abs_y = Mathf.Abs(transform.localScale.y);

        if (Mathf.Abs(transform.position.x - magicCircle.transform.position.x) >= 0.05) // ���Ϳ� magicCircle�� �Ÿ� ���� Ŭ ���� �ٲٱ�
        {
            
            if (transform.position.x < magicCircle.transform.position.x)
                transform.localScale = new Vector2(1 * Abs_x, 1 * Abs_y);
            else if (transform.position.x > magicCircle.transform.position.x)
                transform.localScale = new Vector2(-1 * Abs_x, 1 * Abs_y);
        }

        // �̵�
        Vector2 dirVec = magicCircle.GetComponent<Rigidbody2D>().position - monsterRig.position; // Rigidbody2D �߽� �������� ���� ���
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        monsterRig.MovePosition(monsterRig.position + nextVec);
        
    }

    public void TakeDamage(float damage)
    {
        isAttacked = true;
        Hp -= damage;

        if (isSingleton)
            UiManager.instance.BossHpBar_Update();

        if (Hp <= 0)
        {
            monsterRig.velocity = new Vector3(0, 0); // ���� �����
            isDead = true;
            GetComponent<Collider2D>().enabled = false;

            if (isSingleton)
            {
                UiManager.instance.BossHpBar_OFF();
                GameManager.instance.SpawnLevelUp();
                GameManager.instance.isBoss = false;
            }

            Invoke("Object_OFF", 0.3f);
                

        }
        isAttacked = false;

    }

    public void Freeze()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().mass = 0;
        monsterRenderer.material.color = Color.cyan;
        isFreeze = true;

    }

    public void FreezeEnd()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().mass = tmp_mass;
        monsterRenderer.material.color = Color.white;
        isFreeze = false;
    }


    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("magicCircle") && isFreeze == false)
        {
            collision.gameObject.GetComponent<magicCircleComponent>().TakeDamage(Time.deltaTime * Damage);
            UiManager.instance.HpBarUpdate();
        }
    }
}
