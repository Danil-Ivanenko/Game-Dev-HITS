using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public static EnemyManager instance;
    public int aliveEnemies;
    [SerializeField] string map;
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
        if( aliveEnemies ==0)
        {
            SceneManager.LoadScene(map);
        }
    }
}
