using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathsCounter : MonoBehaviour
{
    int numberOfLifes;
    public TMP_Text DeathsCounterView;

    void Start()
    {
        ResetCounter();
    }

    public void addDeath()
    {
        numberOfLifes--;
        if (numberOfLifes == 0)
        {
            SceneManager.LoadScene(5);
        }
        DeathsCounterView.text = numberOfLifes.ToString();
    }

    public void ResetCounter()
    {
        numberOfLifes = 5;
        DeathsCounterView.text = numberOfLifes.ToString();
    }
}
