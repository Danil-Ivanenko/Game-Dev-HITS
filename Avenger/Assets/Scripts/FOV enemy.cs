using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FOVenemy : MonoBehaviour
{
    [SerializeField] float FOVradius;
    [SerializeField] LayerMask targetlayer;
    [SerializeField] Transform targetTransform;
    [SerializeField] float viewAngle =45;
    [SerializeField] public bool visible;
    [SerializeField] LayerMask wallsLayer;
    [SerializeField] float chasingTime = 5f;
    Collider2D[] targetCol;
    float targetDist;
    public bool chase;
    Vector2 targetDirection;
    public bool hear;

    void Update()
    {
        FOVcheck();
        if( (visible && !chase) || hear )
        {
            chase = true;
            StartCoroutine(Chasing());
        }
        //FOVcheck();
    }
    public float angleView;
    void OnDrawGizmos() 
    {
        //UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, FOVradius);
        Vector2 Deg2Rad(float deg, float euler)
        {

            deg += euler;
            return new Vector2(Mathf.Sin(deg* Mathf.Deg2Rad), Mathf.Cos(deg* Mathf.Deg2Rad));
        } 

        Vector3 positiveAngle = Deg2Rad(viewAngle, -transform.eulerAngles.z);
        Vector3 negativeAngle = Deg2Rad(-viewAngle, -transform.eulerAngles.z);
        Gizmos.DrawLine(transform.position, transform.position + positiveAngle* FOVradius);
        Gizmos.DrawLine(transform.position, transform.position + negativeAngle* FOVradius);
    }
    void FOVcheck()
    {
        targetCol = Physics2D.OverlapCircleAll(transform.position, FOVradius, targetlayer);
        if(targetCol.Length > 0)
        {
            targetTransform = targetCol[0].transform;
            targetDirection = (targetTransform.position - transform.position).normalized;
            targetDist = Vector2.Distance(transform.position, targetTransform.position);
            angleView = Vector2.Angle(transform.up, targetDirection); //added
            if(Vector2.Angle(transform.up, targetDirection) < viewAngle)
            {
                if(!Physics2D.Raycast(transform.position, targetDirection, targetDist, wallsLayer))
                {
                    visible = true;
                }
                else
                {
                    visible = false;
                }
            }
            else
            {
                visible = false;
            }
        }
        else
        {
            visible = false;
        }
    }

    IEnumerator Chasing()
    {
        yield return new WaitForSeconds(chasingTime);
        if(!visible)
        {
            chase = false;
        }
        else
        {
            StartCoroutine(Chasing());
        }
    }
}
