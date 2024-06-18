using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public int type; // 1 -дубинка, 2 - пистолет
    public int id;
    [SerializeField] bool inZone;
    void Start()
    {
        id = Random.Range(0,10000);
    }

    // Update is called once per frame
    void Update()
    {
        if(inZone && WeaponManagment.instance.id == 0 &&  Input.GetMouseButtonDown(1)) // == id
        {
           
            WeaponManagment.instance.type = type;    // fixed
            WeaponManagment.instance.id = id;  // fixed
            WeaponManagment.instance.TakeWeapon();
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            inZone = true;
            //WeaponManagment.instance.type = type;
            //WeaponManagment.instance.id = id; 
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {

            inZone = false;

        }
    }
}
