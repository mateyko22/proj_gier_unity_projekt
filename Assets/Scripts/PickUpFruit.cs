using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFruit : MonoBehaviour
{
    Animator anim;
    FruitsCounter fruitsCounter;
    public AudioSource collectSoundEffect;

    void Start()
    {
        anim = GetComponent<Animator>();
        fruitsCounter = GameObject.Find("Manager").GetComponent<FruitsCounter>();
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            anim.SetTrigger("collected");
            collectSoundEffect.Play();
            fruitsCounter.addFruit();
            Invoke("DestroyObject", 0.5f);
        }
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }

}

