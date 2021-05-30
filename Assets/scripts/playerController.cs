using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float verticalSpeed = 0.5f;
    Rigidbody m_Rigidbody;
    Animator m_Animator;
    bool m_IsGrounded;
    float m_ForwardAmount;


    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                                  RigidbodyConstraints.FreezeRotationZ;
    }


    void Update()
    {
        float forwardMove = Input.GetAxis("Vertical") * moveSpeed;
        float sideMove = Input.GetAxis("Horizontal") * moveSpeed;
        float verticalMove = Input.GetAxis("Jump") * verticalSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            forwardMove *= 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            m_Animator.SetBool("Crouch", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            m_Animator.SetBool("Crouch", false);
        }

        if (verticalMove > 0)
        {
            m_Animator.SetBool("OnGround", false);
            m_Animator.SetFloat("Jump", verticalMove);
        }
        else
        {
            m_Animator.SetBool("OnGround", true);
            m_Animator.SetFloat("Jump", verticalMove);
            m_Animator.SetFloat("JumpLeg", verticalMove);
        }
        
        m_Animator.SetFloat("Forward", forwardMove);
        m_Animator.SetFloat("Turn", sideMove);
    }
}