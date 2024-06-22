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
    
    public void PlaySecondLevel()
    {
        Debug.Log("bim bim bam bam");
        SceneManager.LoadScene("map2");
    }
    
    public void PlayThirdLevel()
    {
        Debug.Log("bim bim bam bam");
        SceneManager.LoadScene("map3");
    }
    
    public void PlayFourthLevel()
    {
        Debug.Log("bim bim bam bam");
        SceneManager.LoadScene("map4");
    }
    
    // public void PlayFifthLevel()
    // {
    //     Debug.Log("bim bim bam bam");
    //     SceneManager.LoadScene("map5");
    // }
    //
    // public void PlaySixthLevel()
    // {
    //     Debug.Log("bim bim bam bam");
    //     SceneManager.LoadScene("map6");
    // }
    //
    // public void PlaySeventhLevel()
    // {
    //     Debug.Log("bim bim bam bam");
    //     SceneManager.LoadScene("map7");
    // }
    //
    // public void PlayEighthLevel()
    // {
    //     Debug.Log("bim bim bam bam");
    //     SceneManager.LoadScene("map8");
    // }
    //
    // public void PlayNinthLevel()
    // {
    //     Debug.Log("bim bim bam bam");
    //     SceneManager.LoadScene("map9");
    // }
    //
    // public void PlayTenthLevel()
    // {
    //     Debug.Log("bim bim bam bam");
    //     SceneManager.LoadScene("map10");
    // }
}
