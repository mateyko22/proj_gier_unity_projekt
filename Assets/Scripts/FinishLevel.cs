using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private bool levelCompleted = false;
    private int activeSceneIndex;
    public AudioSource finishLevelSoundEffect;
    void Start()
    {
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && !levelCompleted)
        {
            finishLevelSoundEffect.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 0.5f);
        }
        
    }
    void CompleteLevel()
    {

        SceneManager.LoadScene(activeSceneIndex + 1);        
    }
}
