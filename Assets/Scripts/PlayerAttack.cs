using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    public enum AttackType
    {
        AttackA,
        AttackB,
        AttackC
    }

    AttackType attacktype;
    PlayerInput pi;
    PlayerMovement pm;
    
    
	void Start ()
    {
        
        pi = GetComponent<PlayerInput>();
        pm = GetComponent<PlayerMovement>();
	}
	
	
	void Update ()
    {
	
	}

    
}
