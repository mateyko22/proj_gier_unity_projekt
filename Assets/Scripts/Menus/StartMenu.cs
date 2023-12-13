using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private int activeSceneIndex;
    public void StartGame()
    {
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (activeSceneIndex == 3 )
        {
            SceneManager.LoadScene(0);
        }
        else 
        {
            SceneManager.LoadScene(activeSceneIndex + 1);
        }
    }
}
