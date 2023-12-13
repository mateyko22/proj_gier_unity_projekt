using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public AudioSource buttonSoundEffect;
    public void StartMenu()
    {
        buttonSoundEffect.Play();
        SceneManager.LoadScene(0);
    }

    public void LevelSelect()
    {
        buttonSoundEffect.Play();
        SceneManager.LoadScene(4);
    }

    public void Level1()
    {
        buttonSoundEffect.Play();
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        buttonSoundEffect.Play();
        SceneManager.LoadScene(2);
    }

    public void NextLevel()
    {
        buttonSoundEffect.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void Quit()
    {
        buttonSoundEffect.Play();
        Application.Quit();
    }
}
