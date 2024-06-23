using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHP : MonoBehaviour
{
    public bool dead;
    Animator anim;
    SpriteRenderer Rend;
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
