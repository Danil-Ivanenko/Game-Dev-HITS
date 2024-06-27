using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : ShotSounds
{
    // Start is called before the first frame update
    Animator anim;
    bool Run;
    public bool AnimDead;
    public bool AnimAttack;
    Vector3 pos;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pos != transform.position)
        {
            Run= true; // работает из-за частоты обноввления
            pos = transform.position;
        }
        else
        {
            Run = false;
        }
        anim.SetBool("Attack", AnimAttack);
        anim.SetBool("Dead", AnimDead);
        anim.SetBool("Run", Run);
        
        
    }

}
