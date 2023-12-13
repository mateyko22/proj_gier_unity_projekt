using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rgdBody;
    Collider2D colliderBody;
    public Transform pointA;
    public Transform pointB;
    public LayerMask WhatIsGround;
    public Transform groundCheck;
    Animator anim;
    private float dirX;
    public int lifesCount;
    private bool isAlive;
    public AudioSource damageSoundEffect;
    public AudioSource deathSoundEffect;

    void Start()
    {
        anim = GetComponent<Animator>();
        rgdBody = GetComponent<Rigidbody2D>();
        colliderBody = GetComponent<Collider2D>();
        dirX = 1;
        lifesCount = 2;
        isAlive = true;
    }

    void Update()
    {
        if (isAlive)
        {
            rgdBody.velocity = new Vector2(dirX * moveSpeed, rgdBody.velocity.y);
            anim.SetFloat("speed", moveSpeed);
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "enemyZoneBorder")
        {
            changeDirection();
        }
        
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (isAlive)
        {
            if (collider.gameObject.tag == "Player")
            {
                rgdBody.gameObject.GetComponent<Animator>().SetTrigger("hit");
                collider.gameObject.GetComponent<Animator>().SetTrigger("hit");
            }
        }
        
        if (collider.gameObject.tag == "Projectile")
        {
            lifesCount--;
            if (lifesCount == 0)
            {
                anim.SetTrigger("death");
                isAlive = false;
                colliderBody.enabled = false;
                deathSoundEffect.Play();
                Invoke("destroyObject", 1.5f);  
            }
            else
            {
                anim.SetBool("is_damaged", true);
                anim.SetTrigger("damage");
                damageSoundEffect.Play();
            }
        }
    }

    void changeDirection()
    {
        dirX *= -1;
        Vector2 heroScale = gameObject.transform.localScale;
        heroScale.x *= -1;
        gameObject.transform.localScale = heroScale;
    }

    void destroyObject()
    {
        Destroy(gameObject);
    }
}

