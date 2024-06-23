using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManer : MonoBehaviour
{
    Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        //if(target == null)
        //{
        //    target = GameObject.FindGameObjectWithTag("Player").transform;
        //}
        //transform.position = new Vector3(target.position.x, target.position.y, -1);

        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }


   
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        Vector2 middlePoint = (target.position + (Vector3)cursorPosition) / 2;

    
        transform.position = new Vector3(middlePoint.x, middlePoint.y, -1);
        
    }
    
}
