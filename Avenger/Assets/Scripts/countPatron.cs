using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class countPatron : MonoBehaviour
{
    public int maxCount;
    public int currentCount;
    public int type;
    private WeaponManagment WM;
    public Text text;
    public Canvas patronsCanvas;

    void Start()
    {
        WM = GetComponent<WeaponManagment>();
    }

    void Update()
    {
        type = WM.type;
        maxCount = WM.maxAmmo;
        currentCount = WM.ammo;

        if (type > 1)
        {
            if (!patronsCanvas.enabled)
            {
                patronsCanvas.enabled = true;
                text.text = $"{currentCount.ToString()} / {maxCount.ToString()}";
            }
            else
            {
                text.text = $"{currentCount.ToString()} / {maxCount.ToString()}"; 
            }
        }
        else
        {
            if (patronsCanvas.enabled)
            {
                patronsCanvas.enabled = false;
            }
        }
    }
}
