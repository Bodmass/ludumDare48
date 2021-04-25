using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class playerJump : MonoBehaviour
{
    private Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
    [SerializeField] private float m_jumpForce = 2f; 
    private Rigidbody m_Rigidbody;

    [SerializeField] LayerMask layerMask;

    private int m_jumpCount = 0;
    [SerializeField] private int m_jumpMax = 1;
    

    [SerializeField] private bool isGrounded;


    [SerializeField] private float difference = 0.1f;
        [SerializeField] private float distance = 0.1f;
    

    private Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update(){

        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("jumpPressed!");
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            m_jumpCount -=1;
         m_Rigidbody.AddForce(jump * m_jumpForce, ForceMode.Impulse);
        }

        if(Input.GetButtonDown("Jump") && !isGrounded && m_jumpCount > 0)
        {
            m_Rigidbody.velocity = new Vector3  (0, 0, 0);
            m_jumpCount -=1;
         m_Rigidbody.AddForce(jump * m_jumpForce, ForceMode.Impulse);
        }

        RaycastHit hit;
        Vector3 newPos = transform.position;
        newPos.y = transform.position.y - difference;
        Ray landingRay = new Ray(newPos, Vector3.down);
        Debug.DrawRay(newPos, Vector3.down * distance);

        // Cast a ray straight downwards.
        if (Physics.Raycast(landingRay, out hit, distance))
        {
            if(hit.collider != null)
            {
                m_jumpCount = m_jumpMax;
                isGrounded = true;
                m_Animator.SetFloat("velocity", 0);
            }
        }
        else
        {          
            isGrounded = false;
            if(m_jumpCount == m_jumpMax)
            {
                m_jumpCount -=1;
            }
            m_Animator.SetFloat("velocity", m_Rigidbody.velocity.y);
        }
        
    }

}