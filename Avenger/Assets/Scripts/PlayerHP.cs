using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHP : ShotSounds
{
    public bool dead;
    Animator anim;
    SpriteRenderer Rend;
    private bool RunSound = false;
    Rigidbody2D Rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        Rend = GetComponent<SpriteRenderer>();
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Dead", dead);
        if(dead)
        {
            if (!RunSound)
            {
                PlaySound(soundsArray[0]);
                RunSound = true;
            }
            if(Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    void OnTriggerStay2D(Collider2D other) 
    {
        if (other.tag == "EnemyBullet")
        {
            if(!dead)
            {
                dead = true;
                Rend.sortingOrder =  -22;
                Rb.isKinematic = true;
            }
            
        }
    }
}
