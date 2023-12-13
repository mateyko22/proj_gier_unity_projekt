using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingHero : MonoBehaviour
{
    public GameObject hero;
    public float smooth;
    private Vector3 currVelocity;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 newCameraPosition = new Vector3(hero.transform.position.x, hero.transform.position.y + 1 , transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newCameraPosition, ref currVelocity, smooth);
    }
}
