using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    BoxCollider2D  col;
    public bool attack;
    EnemyAnimation AnimScript;
    EnemyHP HP;
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        AnimScript = GetComponentInParent<EnemyAnimation>();
        HP =  GetComponentInParent<EnemyHP>();
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MelleeAttack()
    {
        if(!attack && !HP.dead)
        {
            attack = true;
            StartCoroutine(AttackTimer());
        }
        return;

    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(0.3f);
        col.enabled = true;
        AnimScript.AnimAttack = true;
        StartCoroutine(FinishAttack());
    }

    IEnumerator FinishAttack()
    {
        yield return new WaitForSeconds(0.3f);
        col.enabled = false;
        attack = false;
        AnimScript.AnimAttack = false;
    }
}
