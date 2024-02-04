using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public bool GamePause = false; // ���� ���� �Ǵ� ����
    public float attackRange = 1f; // ���� ����
    private bool isAttack = false; // ���� �� ����

    private Collider2D[] collider2Ds; // ���� ������ �迭

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GamePause)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = -1;
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.3f);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameManager.instance.PlaySound(false,0);
                if (GameManager.instance.StaminaUse())
                {
                    isAttack = true;
                    UiManager.instance.StaminaBarUpdate();
                    collider2Ds = Physics2D.OverlapCircleAll(transform.position, attackRange);
                    foreach (Collider2D collider in collider2Ds)
                    {
                        if (collider.tag == "Monster")
                        {

                            collider.gameObject.GetComponent<MonsterComponent>().TakeDamage(GameManager.instance.atk);
                        }
                    }
                }
            }
            else
            {
                if (isAttack == true)
                {
                    Invoke("StaminaRecoverStart", GameManager.instance.stamina_cool);

                }
                else
                {
                    GameManager.instance.StaminaRecover();
                    UiManager.instance.StaminaBarUpdate();
                }
            }
        }
    }

    private void StaminaRecoverStart()
    {
        isAttack = false;
    }

    private void OnDrawGizmos() // ���� ���� �ð�ȭ
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
