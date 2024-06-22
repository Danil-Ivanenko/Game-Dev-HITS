using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToFirstLevel : MonoBehaviour
{
    public void PlayFirstLevel()
    {
        Debug.Log("bim bim bam bam");
        SceneManager.LoadScene("map1");
    }
}
