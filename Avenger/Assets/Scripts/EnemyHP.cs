using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : ShotSounds
{
    public bool dead;
    EnemyAnimation AnimScript;
    [SerializeField] GameObject Weapon;
    private bool soundPlayed = false;
    
    void Start()
    {
        AnimScript = GetComponent<EnemyAnimation>();
        EnemyManager.instance.aliveEnemies++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "PlayerBullet" && ! dead)
        {

            PlaySound(soundsArray[0]);
            AnimScript.AnimDead = true;
            gameObject.GetComponent<Collider2D>().enabled = false; // fixed
            Instantiate(Weapon, transform.position, transform.rotation);
            dead = true;
            EnemyManager.instance.aliveEnemies--;
            
            
        }

        if(other.tag == "SingleWeapon"  && ! dead)
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if(rb.velocity.magnitude > 10f)
            {
                rb.velocity = new Vector2(rb.velocity.x/2, rb.velocity.y/2);
                gameObject.GetComponent<Collider2D>().enabled = false; // fixed
                PlaySound(soundsArray[0]);


                AnimScript.AnimDead = true;
                
                dead = true;
                EnemyManager.instance.aliveEnemies--;
                
                Instantiate(Weapon, transform.position, transform.rotation);
            }
            
        }

    }
}
