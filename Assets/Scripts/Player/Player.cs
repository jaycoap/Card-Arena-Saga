﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Player_Maxhealth = 100; // 플레이어의 체력
    public int Player_Currenthealth; // 플레이어의 현재 체력 
    Collider2D Player_DeadCollider;
    Animator Player_Animator;
    private bool Player_Dead_flag = true; // 플레이어 사망 bool
    public HealthBar Player_HealthBar;//체력바를 추가하기위한 그것에 대한 참조를 만들어야함  그래서 공중 보건 바를 만듬 
    public GameObject Player_DamageDisplay; // 맞은 데미지 표시를 위한 변수 

    private void Start()
    {
        Player_Currenthealth = Player_Maxhealth;  //현재 체력을 나의 maxHealth로 저장
        Player_HealthBar.SetMaxHealth(Player_Maxhealth); //HP를 현재 나의 최대 최력치에 저장한다.
        Player_DeadCollider = GetComponent<Collider2D>();
        Player_Animator = GetComponent<Animator>();
    }

    public void Player_TakeDamage() //대미지를 입을 함수 
    {
        Player_Currenthealth -= Enemy_Dish_Combat.Enemy_Dish_Damage; // 현재체력을 damage 매개변수를 받아 그만큼 감소 
        Player_HealthBar.SetHealth(Player_Currenthealth); // 감소한피를 적용 
        
        GameObject Player_Display = Instantiate(Player_DamageDisplay, transform.position, Quaternion.identity);
        Player_Display.transform.GetChild(0).GetComponent<TextMesh>().text = Enemy_Dish_Combat.Enemy_Dish_Damage.ToString();

        if (Player_Currenthealth <= 0)// 플레이어 사망
        {
            if (Player_Dead_flag) { 
                Player_Dead_flag = false;
                Player_Animator.SetTrigger("Pl.Dead");
                Die();
            }
        }
    }
    private void Die() //플레이어 사망시 Collider Enabled 해제
    {
        
        Invoke("DeadActive", 2f);

    }

    void DeadActive() //플레이어 사망시 Active 해제
    {
        gameObject.SetActive(false);
    }

    private void Player_Dead_flag_True() // Enemy 사망후 공격 방지
    {
        Player_Dead_flag = true;
    }


}
