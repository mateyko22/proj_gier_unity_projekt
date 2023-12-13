using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform navStartPoint;
    public Transform navEndPoint;
    private Vector2 startPoint;
    private Vector2 endPoint;
    public float speed;
    private Vector2 currentPtatformPosition;

    void Start()
    {
        startPoint = navStartPoint.position;
        endPoint = navEndPoint.position;
        Destroy(navStartPoint.gameObject);
        Destroy(navEndPoint.gameObject);
    }

    void Update()
    {
        currentPtatformPosition = Vector2.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speed, 1));
        transform.position = currentPtatformPosition;
    }
    
    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            collider.transform.parent = transform;
    }

    void OnTriggerExit2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            collider.transform.parent = null;
    }
}

