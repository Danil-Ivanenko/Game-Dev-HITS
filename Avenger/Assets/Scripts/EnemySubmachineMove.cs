using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemySubmachineMove : MonoBehaviour
{
public Transform[] targets;
    public float delay = 0;
    [SerializeField] int startAngle;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform FirePoint;
    [SerializeField] float bulletSpeed = 30;
    int index;
    bool chase;
    bool visible;
    IAstarAI agent;
    float switchTime = float.PositiveInfinity;
    GameObject Player;
    Transform playerPos;
    FOVenemy fov;
    EnemyHP HP;
    float cooldown = 0.06f;
    int reloadinAmmo =0;
    float reloadCooldown = 2.5f;
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
            if(reloadinAmmo >30)
            {
                StartCoroutine(ReloadCoroutine());
            }
            
            if(visible && Time.time > lastFireTime + cooldown && reloadinAmmo <=30  && fov.angleView<10)
            {

                GameObject projectile = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                projectile.GetComponent<Rigidbody2D>().AddForce(FirePoint.up* bulletSpeed, ForceMode2D.Impulse);
                lastFireTime = Time.time;
                reloadinAmmo++;
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
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            chase = true;
        }
    }

    IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        reloadinAmmo =0;
    }

}
