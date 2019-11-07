using UnityEngine;
using System.Collections;

public class EnergyMover : MonoBehaviour
{
    
    public float eSpeed;
    public float cycle;
    public GameObject ninja;

    Rigidbody2D rbE;
    bool flipMode;
    

    void Awake()
    {
        rbE = GetComponent<Rigidbody2D>();
        ninja = GameObject.Find("ninja");
        flipMode = ninja.GetComponent<SpriteRenderer>().flipX;
    }

   
    void FixedUpdate()
    {
       cycle += Time.fixedDeltaTime;
        
        if (cycle > 1)
        {
            Destroy(gameObject);
            NinjaScript.energyNum--;
        }
        switch (flipMode)
        {
            case true:
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                rbE.velocity = -transform.right * eSpeed;
                break;

            case false:
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                rbE.velocity = transform.right * eSpeed;
                break;
        }
        
    }

}
