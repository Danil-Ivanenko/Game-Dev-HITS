using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSript : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    Rigidbody2D Rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Rotation", Rb.velocity.magnitude);
    }
}
