using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class moveEnemy1 : MonoBehaviour
{
    public Transform[] targets;
    public float delay = 0;
    int index;
    bool chase;
    IAstarAI agent;
    float switchTime = float.PositiveInfinity;
    GameObject Player;
    Transform playerPos;
    FOVenemy fov;
    void Awake () 
    {
        agent = GetComponent<IAstarAI>();
        transform.eulerAngles = new Vector2(180, 180);
    }
    void Start() 
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        fov = GetComponent<FOVenemy>();
    }

    
    void Update () {
        chase = fov.chase;
        playerPos= Player.transform;

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

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            chase = true;
        }
    }
}
