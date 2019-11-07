using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    public float m_HorizontalMove;
    public bool m_Jump;
    public bool m_AttackA;
    public bool m_AttackB;
    public bool m_AttackC;

    void Update()
    {
        m_HorizontalMove = Input.GetAxis("Horizontal");
        m_Jump = Input.GetButtonDown("Jump");
        m_AttackA = Input.GetButton("Fire1");
        m_AttackB = Input.GetButton("Fire2");
        m_AttackC = Input.GetButton("Fire3");
    }
    

}
