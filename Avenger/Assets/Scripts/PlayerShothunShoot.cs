using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShothunShoot : MonoBehaviour
{
[SerializeField] GameObject CurWeapon;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform FirePoint;
    [SerializeField] float throwSpeed = 255;
    [SerializeField] float bulletSpeed = 30;
    float cooldown = 0.5f;
    float lastFireTime;
    Collider2D NoiseZone;
    [SerializeField] GameObject BasicPlayer;

    void Start()
    {

        NoiseZone = transform.GetChild(1).GetComponent<Collider2D>();
        FirePoint = transform.GetChild(0).transform;
        if(Time.time < 1f)
        {
            WeaponManagment.instance.type = 2;    // fixed
            WeaponManagment.instance.id = Random.Range(0,10000);   // fixed
            WeaponManagment.instance.ammo = 4;    // fixed
            WeaponManagment.instance.maxAmmo = 4; 
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
                weapon.GetComponent<PickUpShotgun>().ammo = WeaponManagment.instance.ammo;
                weapon.GetComponent<PickUpShotgun>().id = WeaponManagment.instance.id;
                WeaponManagment.instance.type = 0;    // fixed
                WeaponManagment.instance.id = 0;   // fixed
                WeaponManagment.instance.ammo = 0;    // fixed
                WeaponManagment.instance.maxAmmo = 0; 
                Instantiate(BasicPlayer, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if(Input.GetMouseButtonDown(0) &&  WeaponManagment.instance.ammo > 0)
            {
                GameObject projectile1 = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                GameObject projectile2 = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                GameObject projectile3 = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                projectile1.GetComponent<Rigidbody2D>().AddForce((FirePoint.up + new Vector3(-0.1f, -0.1f, 0.0f)) * bulletSpeed, ForceMode2D.Impulse);
                projectile2.GetComponent<Rigidbody2D>().AddForce(FirePoint.up* bulletSpeed, ForceMode2D.Impulse);
                projectile3.GetComponent<Rigidbody2D>().AddForce((FirePoint.up + new Vector3(+0.1f, +0.1f, 0.0f))* bulletSpeed, ForceMode2D.Impulse);
                lastFireTime = Time.time;
                WeaponManagment.instance.ammo--;
                NoiseZone.enabled =true;
            }
            else
            {
                NoiseZone.enabled =false;
            }
        }
    }
}
