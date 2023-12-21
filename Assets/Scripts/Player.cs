using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public Transform startPoint;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;
    private bool grouned;
    private bool doubleJump;
    public bool facingRight = true;
    Rigidbody2D rgdBody;
    Animator anim;
    DeathsCounter deathsCounter;
    public AudioSource jumpSoundEffect;
    public AudioSource doubleJumpSoundEffect;
    public AudioSource hitSoundEffect;
    public AudioSource shootSoundEffect;

    public ProjectileBehaviour projectilePrefab;
    public Transform launchOffset;
    public Quaternion tempQuaternion;

    void Start()
    {
        anim = GetComponent<Animator>();
        rgdBody = GetComponent<Rigidbody2D>();
        deathsCounter = GameObject.Find("Manager").GetComponent<DeathsCounter>();
    }

    void FixedUpdate()
    {
        grouned = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Hero_hit")) {
            hitSoundEffect.Play();
            rgdBody.velocity = Vector2.zero;
            return;
        }

        if (grouned)
        {
            doubleJump = false;
            float horizontalMove = Input.GetAxis("Horizontal");
            anim.SetFloat("speed", Mathf.Abs(horizontalMove));
        }
        if(!grouned)
        {
            if (rgdBody.velocity.y < 0)
            {
                anim.SetBool("falling", true);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.W) && grouned)
        {
            Jump();
            anim.SetTrigger("jump");
            jumpSoundEffect.Play();
        }

        if (Input.GetKeyDown(KeyCode.W) && !grouned && !doubleJump)
        {
            Jump();
            doubleJump = true;
            anim.SetTrigger("double_jump");
            doubleJumpSoundEffect.Play();
        }

        if (Input.GetKey(KeyCode.D))
        {
            rgdBody.velocity = new Vector2 (moveSpeed, rgdBody.velocity.y); 
            Vector2 heroScale = gameObject.transform.localScale;
            heroScale.x = 1;
            facingRight = true;
            gameObject.transform.localScale = heroScale;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rgdBody.velocity = new Vector2 (-moveSpeed, rgdBody.velocity.y); 
            Vector2 heroScale = gameObject.transform.localScale;
            heroScale.x = -1;
            facingRight = false;
            gameObject.transform.localScale = heroScale;
        }

        if (Input.GetButtonDown("Jump"))
        {
            tempQuaternion = transform.rotation;
            if (facingRight)
            {
                tempQuaternion = transform.rotation * Quaternion.Euler(0, 180, 0);
            }
            else
            {
                tempQuaternion = transform.rotation;
            }
            Instantiate(projectilePrefab, launchOffset.position, tempQuaternion);
            shootSoundEffect.Play();
        }
    }

    void Jump()
    {
        rgdBody.velocity = new Vector2 (rgdBody.velocity.x, jumpHeight);         
    }

    public void RestartHero()
    {
        gameObject.transform.position = startPoint.position;
        deathsCounter.addDeath();
    }
}

