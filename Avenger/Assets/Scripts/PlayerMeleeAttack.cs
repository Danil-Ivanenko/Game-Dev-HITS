using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : ShotSounds
{
    // Start is called before the first frame update
    [SerializeField] GameObject CurWeapon;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform FirePoint;
    [SerializeField] float throwSpeed = 255;
    [SerializeField] float bulletSpeed = 30;
    [SerializeField] GameObject BasicPlayer;
    BoxCollider2D  col;
    Animator anim;

    float cooldown = 0.75f;
    float lastFireTime =- 0.75f;
    public bool attack;
    PlayerHP HP;
    //EnemyAnimation AnimScript;
    void Start()
    {
        FirePoint = transform.GetChild(0).transform;
        col = GetComponentInChildren<BoxCollider2D>();
        anim = GetComponent<Animator>();
        col.enabled = false; 
        HP = GetComponent<PlayerHP>();
        
    }

    void Update()
    {
        if(Time.time > lastFireTime + cooldown && !HP.dead)
        {
            if(Input.GetMouseButtonDown(1))
            {
                GameObject weapon = Instantiate(CurWeapon, FirePoint.position, FirePoint.rotation);
                weapon.GetComponent<Rigidbody2D>().AddForce(FirePoint.up* throwSpeed, ForceMode2D.Impulse);
                weapon.GetComponent<PickUpWeapon>().id = WeaponManagment.instance.id;
                WeaponManagment.instance.type = 0;    // fixed
                WeaponManagment.instance.id = 0;   // fixed1

                

                Instantiate(BasicPlayer, transform.position, transform.rotation);
                AudioSource.PlayClipAtPoint(soundsArray[1], transform.position);
                Destroy(gameObject);
            }
  
            
            if(Input.GetMouseButtonUp(0))
            {
                
                MelleeAttack();
                PlaySound(soundsArray[0]);
            }
        }

    }

    public void MelleeAttack()
    {
        attack = true;
        anim.SetBool("Attack",attack);
        StartCoroutine(AttackTimer());
        lastFireTime = Time.time;
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
