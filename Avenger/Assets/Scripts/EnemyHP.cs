using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public bool dead;
    EnemyAnimation AnimScript;
    void Start()
    {
        AnimScript = GetComponent<EnemyAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "PlayerBullet")
        {
            AnimScript.AnimDead = true;
            dead = true;
            gameObject.GetComponent<Collider2D>().enabled = false; // fixed
            
        }
    }
}
