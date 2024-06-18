using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMeleeTriger : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyMelee AttackScript;
    void Start()
    {
        AttackScript = transform.GetChild(0).GetComponent<EnemyMelee>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            AttackScript.MelleeAttack();
        }
    }
}
