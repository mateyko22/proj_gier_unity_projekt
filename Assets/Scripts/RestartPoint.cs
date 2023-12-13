using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPoint : MonoBehaviour
{
    RestartPointsManager restartPointsManager;
    Animator anim;
    public AudioSource checkpointSoundEffect;
    private bool checkpoint;

    void Start()
    {
        restartPointsManager = GameObject.Find("Manager").GetComponent<RestartPointsManager>();
        anim = GetComponent<Animator>();
        checkpoint = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && !checkpoint)
        {
            checkpoint = true;
            anim.SetTrigger("getCheckpoint");
            checkpointSoundEffect.Play();
            restartPointsManager.UpdateStartPoint(this.gameObject.transform);
        }
    }
}
