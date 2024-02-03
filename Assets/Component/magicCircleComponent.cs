using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicCircleComponent : MonoBehaviour
{
    // ½ºÅÈ
    public float Hp = 500;
    public float maxHp = 500;

    // º¯¼ö
    public bool isAttacked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        isAttacked = true;

        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            gameObject.SetActive(false);

            GameManager.instance.GameOver();
        }
        isAttacked = false;
    }
}
