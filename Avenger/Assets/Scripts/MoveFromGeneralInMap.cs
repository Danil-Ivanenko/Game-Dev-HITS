using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveFromGeneralInMap : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Base");
    }

    public void ExitGame()
    {
        Debug.Log("bim bim bam bam");
        Application.Quit();
    }
}
