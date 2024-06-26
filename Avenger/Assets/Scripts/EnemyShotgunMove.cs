using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyShotgunMove : ShotSounds
{
public Transform[] targets;
    public float delay = 0;
    [SerializeField] int startAngle;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform FirePoint;
    [SerializeField] float throwSpeed = 255;
    [SerializeField] float bulletSpeed = 30;
    int index;
    bool chase;
    bool visible;
    IAstarAI agent;
    private bool soundPlayed = false;
    float switchTime = float.PositiveInfinity;
    GameObject Player;
    Transform playerPos;
    FOVenemy fov;
    EnemyHP HP;
    float cooldown = 1.5f;
    float lastFireTime;
    void Awake () 
    {
        agent = GetComponent<IAstarAI>();
        transform.eulerAngles = new Vector3(0, 0, startAngle );
        HP = GetComponent<EnemyHP>();
    }
    void Start() 
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        fov = GetComponent<FOVenemy>();
        FirePoint = transform.GetChild(0).transform;
    }

    
    void Update () {
        if(!HP.dead)
        {
            if(Player == null)
            {
                Player = GameObject.FindGameObjectWithTag("Player");
            }
            chase = fov.chase;
            visible = fov.visible;
            playerPos= Player.transform;
            
            if(visible && Time.time > lastFireTime + cooldown && fov.angleView<10)
            {

                
                GameObject projectile1 = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                GameObject projectile2 = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                GameObject projectile3 = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                projectile1.GetComponent<Rigidbody2D>().AddForce((FirePoint.up + new Vector3(-0.1f, -0.1f, 0.0f)) * bulletSpeed, ForceMode2D.Impulse);
                projectile2.GetComponent<Rigidbody2D>().AddForce(FirePoint.up* bulletSpeed, ForceMode2D.Impulse);
                projectile3.GetComponent<Rigidbody2D>().AddForce((FirePoint.up + new Vector3(+0.1f, +0.1f, 0.0f))* bulletSpeed, ForceMode2D.Impulse);
                PlaySound(soundsArray[0]);

                lastFireTime = Time.time;
            }

            if(!chase) 
            {
                if (targets.Length == 0) return;

                bool search = false;
                if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime)) {
                    switchTime = Time.time + delay;
                }

                if (Time.time >= switchTime) {
                    index = index + 1;
                    search = true;
                    switchTime = float.PositiveInfinity;
                }

                index = index % targets.Length;
                agent.destination = targets[index].position;

                if (search) agent.SearchPath();
            }
            if (chase )
            {
                agent.destination = playerPos.position;
            }
        }
        else
        {
            agent.destination = transform.position;
            if (!soundPlayed)
            {
                PlaySound(soundsArray[1]);
                soundPlayed = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            chase = true;
        }
    }
}
