using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMelee : ShotSounds
{
 [SerializeField] GameObject CurWeapon;

    BoxCollider2D  col;
    Animator anim;
    float cooldown = 0.75f;
    float lastFireTime =- 0.75f;
    public bool attack;
    PlayerHP HP;
    //EnemyAnimation AnimScript;
    void Start()
    {
        col = GetComponentInChildren<BoxCollider2D>();
        anim = GetComponent<Animator>();
        col.enabled = false; 
        HP = GetComponent<PlayerHP>();
    }

    void Update()
    {
        if(Time.time > lastFireTime + cooldown && !HP.dead )
        {
            
            if(Input.GetMouseButtonUp(0) )
            {
                MelleeAttack();
            }
        }

    }

    public void MelleeAttack()
    {
        attack = true;
        anim.SetBool("Attack",attack);
        StartCoroutine(AttackTimer());
        lastFireTime = Time.time;
        PlaySound(soundsArray[0]);
        return;

    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(0.3f);
        col.enabled = true;
        StartCoroutine(FinishAttack());
    }

    IEnumerator FinishAttack()
    {
        yield return new WaitForSeconds(0.3f);
        col.enabled = false;
        attack = false;
        anim.SetBool("Attack",attack);
        
    }
}
