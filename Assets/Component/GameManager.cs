using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //기본 변수들
    //public int hp = 100;  -> hp는 magicCircleComponent에서 직접 컨트롤
    public int gold = 10;
    public float atk = 1f;
    public bool isGameOver = false;
    
    
    public static GameManager instance = null;
    public magicCircleComponent magicCircle;


    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            
        }

        else
            Destroy(this.gameObject);
        
    }

    void Start()
    {

    }


    
    public void ChangeAtk(int data)
    {
        atk += data;
        if (atk < 0)
        {
            atk = 0;
            
        }
    }

    public void ChangeGold(int data)
    {
        gold += data;
        if (gold < 0)
        {
            gold = 0;
            
        }
    }

}
