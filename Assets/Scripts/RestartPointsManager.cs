using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPointsManager : MonoBehaviour
{
    public Player playerController;

    void Start()
    {
        
    }

    public void UpdateStartPoint(Transform newPosition)
    {
        playerController.startPoint = newPosition;
    }
}
