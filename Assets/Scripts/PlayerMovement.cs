using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float force;
    public bool grounded;

    private float vSpeed;
    

    PlayerInput playerInput;
    Rigidbody2D playerRigidBody;
    

	void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        
    }

	void Start ()
    {
        playerInput = GetComponent<PlayerInput>();
    }
	
	
	void Update ()
    {
        vSpeed = playerRigidBody.velocity.y;
        Move(speed, playerInput.m_HorizontalMove);
        Jump(playerInput.m_Jump, grounded, force);
        Grounded(vSpeed);
       
	}

    void Move(float Speed, float horizontalMovement)
    {
        playerRigidBody.velocity = new Vector2(horizontalMovement * Speed, playerRigidBody.velocity.y);
    }
    
    void Jump(bool jumped, bool g, float jumpForce)
    {
        if (jumped && g)
        {
            playerRigidBody.AddForce(new Vector2(0.0f, jumpForce));
        }
        
    }
    void Grounded(float VS)
    {
        if (VS >= -0.1f && VS <= 0.1f)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
}
