using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerPistolShoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject CurWeapon;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform FirePoint;
    [SerializeField] float throwSpeed = 255;
    [SerializeField] float bulletSpeed = 30;
    float cooldown = 0.1f;
    float lastFireTime;

    [SerializeField] GameObject BasicPlayer;

    void Start()
    {
        FirePoint = transform.GetChild(0).transform;

    }

    void Update()
    {
        if(Time.time > lastFireTime + cooldown)
        {
            if(Input.GetMouseButtonDown(1))
            {
                GameObject weapon = Instantiate(CurWeapon, FirePoint.position, FirePoint.rotation);
                weapon.GetComponent<Rigidbody2D>().AddForce(FirePoint.up* throwSpeed, ForceMode2D.Impulse);
                weapon.GetComponent<PickUpPistol>().ammo = WeaponManagment.instance.ammo;
                WeaponManagment.instance.type = 0;    // fixed
                WeaponManagment.instance.id = 0;   // fixed
                WeaponManagment.instance.ammo = 0;    // fixed
                WeaponManagment.instance.maxAmmo = 0; 
                Instantiate(BasicPlayer, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if(Input.GetMouseButtonDown(0) &&  WeaponManagment.instance.ammo > 0)
            {
                GameObject projectile = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                projectile.GetComponent<Rigidbody2D>().AddForce(FirePoint.up* bulletSpeed, ForceMode2D.Impulse);
                lastFireTime = Time.time;
                WeaponManagment.instance.ammo--;
            }
        }
    }

}
