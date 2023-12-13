using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FruitsCounter : MonoBehaviour
{
    int numberOfFruits;
    public TMP_Text FruitsCounterView;

    void Start()
    {
        ResetCounter();
    }

    public void addFruit()
    {
        numberOfFruits++;
        FruitsCounterView.text = numberOfFruits.ToString();
    }

    public void ResetCounter()
    {
        numberOfFruits = 0;
        FruitsCounterView.text = numberOfFruits.ToString();
    }
}
