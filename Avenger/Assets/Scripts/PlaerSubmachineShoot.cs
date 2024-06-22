using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaerSubmachineShoot : MonoBehaviour
{
 [SerializeField] GameObject CurWeapon;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform FirePoint;
    [SerializeField] float throwSpeed = 500;
    [SerializeField] float bulletSpeed = 30;
    float cooldown = 0.05f;
    float lastFireTime;

    [SerializeField] GameObject BasicPlayer;

    void Start()
    {
        FirePoint = transform.GetChild(0).transform;
        if(Time.time < 1f)
        {
            WeaponManagment.instance.type = 3;    // fixed
            WeaponManagment.instance.id = Random.Range(0,10000);   // fixed
            WeaponManagment.instance.ammo = 30;    // fixed
            WeaponManagment.instance.maxAmmo = 30; 
        }
    }

    void Update()
    {
        if(Time.time > lastFireTime + cooldown)
        {
            if(Input.GetMouseButtonDown(1))
            {
                GameObject weapon = Instantiate(CurWeapon, FirePoint.position, FirePoint.rotation);
                weapon.GetComponent<Rigidbody2D>().AddForce(FirePoint.up* throwSpeed, ForceMode2D.Impulse);
                weapon.GetComponent<PickUpSubmachine>().ammo = WeaponManagment.instance.ammo;
                weapon.GetComponent<PickUpSubmachine>().id = WeaponManagment.instance.id;
                WeaponManagment.instance.type = 0;    // fixed
                WeaponManagment.instance.id = 0;   // fixed
                WeaponManagment.instance.ammo = 0;    // fixed
                WeaponManagment.instance.maxAmmo = 0; 
                Instantiate(BasicPlayer, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if(Input.GetMouseButton(0) &&  WeaponManagment.instance.ammo > 0)
            {
                GameObject projectile = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                projectile.GetComponent<Rigidbody2D>().AddForce(FirePoint.up* bulletSpeed, ForceMode2D.Impulse);
                lastFireTime = Time.time;
                WeaponManagment.instance.ammo--;
            }
        }
    }
}
