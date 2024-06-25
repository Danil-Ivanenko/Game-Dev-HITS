using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveInScene : MonoBehaviour
{
    public void StartFirstLevel()
    {
        SceneManager.LoadScene("map1");
    }
    
    public void StartSecondLevel()
    {
        SceneManager.LoadScene("map2");
    }
    
    public void StartThirdLevel()
    {
        SceneManager.LoadScene("map3");
    }
    
    public void StartFourthLevel()
    {
        SceneManager.LoadScene("map4");
    }
    
    public void StartFifthLevel()
    {
        SceneManager.LoadScene("map5");
    }
    
    public void StartSixthLevel()
    {
        SceneManager.LoadScene("map6");
    }
    
    public void StartSeventhLevel()
    {
        SceneManager.LoadScene("map7");
    }
    
    public void StartEighthLevel()
    {
        SceneManager.LoadScene("map8");
    }
    
    public void StartNinthLevel()
    {
        SceneManager.LoadScene("map9");
    }
    
    public void StartTenthLevel()
    {
        SceneManager.LoadScene("map10");
    }

    public void MoveInTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
