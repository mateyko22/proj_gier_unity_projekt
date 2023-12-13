using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 4.5f;
    public Player playerController;
    private bool kk;
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
        Invoke("destroyObject", 3f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        destroyObject();        
    }

    void destroyObject()
    {
        Destroy(gameObject);
    }
}
