using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D Rb;
     [SerializeField] float speed = 3;
    Animator anim;
    PlayerHP HP;
    public bool run;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        HP = GetComponent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!HP.dead)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
            Rb.velocity = new Vector2(moveDirection.x*speed, moveDirection.y*speed);
            if (moveX != 0 || moveY != 0 )
            {
                run = true;
            }
            if (moveX == 0 && moveY == 0 )
            {
                run = false;
            }
            
        }
        else
        {
            Rb.velocity = new Vector2(0, 0);
        }
        anim.SetBool("Run",run);
    }
}
