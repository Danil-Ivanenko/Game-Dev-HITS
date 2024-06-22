using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearingZone : MonoBehaviour
{
    FOVenemy fov;
    void Start()
    {
        fov = GetComponentInParent<FOVenemy>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "NoiseZone")
        {
            fov.hear = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "NoiseZone")
        {
            fov.hear = false;
        }
    }
}
