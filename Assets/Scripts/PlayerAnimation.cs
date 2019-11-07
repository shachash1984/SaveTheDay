using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{

    public bool isGrounded, isIdle, isJumping, isAttackA, isAttackB, isAttackC, isDead;
    public float horizontalSpeed;
    public float verticalSpeed;

    Animator animator;
    PlayerInput playerInput;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody2D;




    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();


    }

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        horizontalSpeed = Mathf.Abs(playerInput.m_HorizontalMove);
        verticalSpeed = rigidBody2D.velocity.y;

        animator.SetFloat("HorizontalSpeed", horizontalSpeed);
        animator.SetFloat("VerticalSpeed", verticalSpeed);
        animator.SetBool("Grounded", playerMovement.grounded);
        animator.SetBool("m_AttackA", playerInput.m_AttackA);
        animator.SetBool("m_AttackB", playerInput.m_AttackB);
        animator.SetBool("m_AttackC", playerInput.m_AttackC);


        Flip(spriteRenderer, playerInput.m_HorizontalMove);
       
    }

    void Flip(SpriteRenderer sr, float hSpeed)
    {
        if (hSpeed > 0)
        {
            sr.flipX = false;
        }
        else if (hSpeed < 0)
        {
            sr.flipX = true;
        }
    }

    
   
}
