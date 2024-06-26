using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public bool dead;
    EnemyAnimation AnimScript;
    [SerializeField] GameObject Weapon;
    private bool soundPlayed = false;
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
        if(other.tag == "PlayerBullet" )
        {
            

            AnimScript.AnimDead = true;

            Instantiate(Weapon, transform.position, transform.rotation);
            
            dead = true;
            gameObject.GetComponent<Collider2D>().enabled = false; // fixed
            
        }

        if(other.tag == "SingleWeapon" )
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if(rb.velocity.magnitude > 10f)
            {
                rb.velocity = new Vector2(rb.velocity.x/2, rb.velocity.y/2);
                AnimScript.AnimDead = true;
                dead = true;
                gameObject.GetComponent<Collider2D>().enabled = false; // fixed
                Instantiate(Weapon, transform.position, transform.rotation);
            }
            
        }

    }
}
