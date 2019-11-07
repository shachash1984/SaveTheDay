using UnityEngine;
using System.Collections;

public class NinjaScript : MonoBehaviour
{
    public float force;
    public float speed;
    public static bool isRunning, isAttacka, isAttackb, isAttackc, isJumping, isFiring;
    public GameObject energyShot;
    public GameObject energySpawn;
    public float delay;
    public static int energyNum;
   
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private GroundedScript gs;
    private float counter;
    private Quaternion energyDirection;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        gs = GetComponentInChildren<GroundedScript>();
    }
    void Update()
    {
        if(!isJumping)
        {
            isJumping = Input.GetKeyDown(KeyCode.UpArrow);
        }
        
    }
    void FixedUpdate()
    {
        
        animator.SetFloat("VSpeed", rigidbody2d.velocity.y);
        animator.SetFloat("HSpeed", rigidbody2d.velocity.x);
        float moveHorizontal = Input.GetAxis("Horizontal");
        rigidbody2d.velocity = new Vector2(moveHorizontal * speed, rigidbody2d.velocity.y);
        Move();
        Flip();
        isJumping = false;
        
    }
    void Move()
    {
        if(gs.isGrounded)
        {
            animator.SetBool("isGrounded", true);
            animator.SetBool("AttackA", false);
            animator.SetBool("AttackB", false);
            animator.SetBool("AttackC", false);

            if (rigidbody2d.velocity.x < 0)
            {
                energySpawn.transform.localPosition = new Vector3(-7, -2.2f);
                //animator.SetBool("isRunning", true);
                if (isJumping)
                {
                    Jump();
                }
            }
            else if (rigidbody2d.velocity.x > 0)
            {
                energySpawn.transform.localPosition = new Vector3(7, -2.2f);
                //animator.SetBool("isRunning", true);
                if (isJumping)
                {
                    Jump();
                }
             }
            else if (Input.GetKey(KeyCode.Z))
            {
                animator.SetBool("AttackA", true);
                counter++;
                if ((counter > delay) && (energyNum < 1))
                {
                    Shoot();
                }
            }
            else if (Input.GetKey(KeyCode.X))
            {
                animator.SetBool("AttackB", true);
            }
            else if (Input.GetKey(KeyCode.C))
            {
                animator.SetBool("AttackC", true);
            }
            else if (isJumping && gs.isGrounded)
            {
                Jump();
            }
            else if (animator.GetBool("isGrounded"))
            {
                counter = 0;
            }
        }
    } 

    void Shoot()
    {
        energyDirection = energySpawn.transform.rotation;
        Instantiate(energyShot, energySpawn.transform.position, energyDirection);
        energyNum++;
       
    }
    void Jump()
    {
        animator.SetBool("isGrounded", false);
        gs.isGrounded = false;
        rigidbody2d.AddForce(new Vector2(0f, force));
    }
    void Flip()
    {
        if (rigidbody2d.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (rigidbody2d.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }   
     
}
    
    
    



    


    
