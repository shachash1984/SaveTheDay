using UnityEngine;
using System.Collections;

public class GroundedScript : MonoBehaviour {


    public bool isGrounded;

    void FixedUpdate()
    {

        isGrounded = false;
        gameObject.GetComponent<Animator>().SetBool("isGrounded", false);

        Collider2D[] groundCheck = Physics2D.OverlapCircleAll(gameObject.transform.position, 0.3f);

        for (int i = 0; i < groundCheck.Length; i++)
        {
            Debug.DrawLine(groundCheck[i].transform.position, gameObject.transform.position);
            if (groundCheck[i] != gameObject)
            {
                isGrounded = true;
                gameObject.GetComponent<Animator>().SetBool("isGrounded", true);
            }

        }
    }

}
