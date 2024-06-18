using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D Rb;
    PlayerHP HP;
    Camera camera;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        HP = GetComponent<PlayerHP>();
        Rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!HP.dead)
        {
            Vector2 mouse = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 gunsight = mouse - Rb.position;
            float playerRotate = Mathf.Atan2(gunsight.y, gunsight.x)* Mathf.Rad2Deg;
            Rb.rotation =  playerRotate - 90;
        }
        else
        {
            Rb.rotation =  0;
        }
    }
}
