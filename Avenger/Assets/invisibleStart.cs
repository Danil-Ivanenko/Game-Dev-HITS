using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibleStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().enabled = false; // Отключаем Renderer при запуске игры
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
