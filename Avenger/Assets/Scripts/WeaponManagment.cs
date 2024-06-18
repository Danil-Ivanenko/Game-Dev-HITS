using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagment : MonoBehaviour
{
    // Start is called before the first frame update
    public static WeaponManagment instance;
    public int type;
    public int id;
    public int ammo;
    public int maxAmmo;
    [SerializeField] GameObject CrowbarPlayer;
    [SerializeField] GameObject PistolPlayer;
    void Awake() 
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeWeapon()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        switch(type)
        {
            case 1:
            Instantiate(CrowbarPlayer, Player.transform.position, Player.transform.rotation);
            Destroy(Player);
            break;
            case 2:
            Instantiate(PistolPlayer, Player.transform.position, Player.transform.rotation);
            Destroy(Player);
            break;

        }

    }
}
