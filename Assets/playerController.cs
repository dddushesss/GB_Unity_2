using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private float verticalSpeed = 0.05f;
    Rigidbody m_Rigidbody;
    Animator m_Animator;
    CapsuleCollider m_Capsule;
    bool m_IsGrounded;
    float m_ForwardAmount;
    private Camera _mainCamera;


    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Capsule = GetComponent<CapsuleCollider>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                                  RigidbodyConstraints.FreezeRotationZ;
        _mainCamera = Camera.main;
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
        
        
        m_Animator.SetFloat("Forward", forwardMove);
        m_Animator.SetFloat("Turn", sideMove);
    }
}