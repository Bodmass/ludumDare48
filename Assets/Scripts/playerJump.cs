using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class playerJump : MonoBehaviour
{
    private Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
    [SerializeField] private float m_jumpForce = 2f;
    private Rigidbody m_Rigidbody;

    private bool isGrounded;


    float difference = 0.1f;

    private Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
         m_Rigidbody.AddForce(jump * m_jumpForce, ForceMode.Impulse);
        }

        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 differenceVector = new Vector3(transform.position.x, transform.position.y - difference, transform.position.z);

        if(Physics.Linecast(transform.position, differenceVector))
        {
            isGrounded = true;
            m_Animator.SetFloat("velocity", 0);
        }
        else
        {
            isGrounded = false;
            m_Animator.SetFloat("velocity", m_Rigidbody.velocity.y);
        }
        
    }

}