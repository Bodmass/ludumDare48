using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float m_Speed = 5f;    
    private Rigidbody m_Rigidbody;

    private SpriteRenderer m_spriteRenderer;
    private Transform m_spriteTransform;


    private Vector3 movement;

    private Transform cameraTransform;

    private Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        cameraTransform = Camera.main.GetComponentInParent<Transform>();
        m_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        m_spriteTransform = m_spriteRenderer.GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(GetComponent<ConversationManager>().isTalking)
        {
            return;
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        m_Animator.SetFloat("moveX",movement.x);
        m_Animator.SetFloat("moveZ",movement.z);


        movement = cameraTransform.TransformDirection(movement);
        movement.y = 0.0f;

       



        m_Rigidbody.MovePosition(transform.position + movement * m_Speed * Time.deltaTime); 
    }

    void Update() {

            if(GetComponent<ConversationManager>().isTalking)
            {
                return;
            }

        if(Input.GetKeyDown(KeyCode.A))
        {
            m_spriteRenderer.flipX=true;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            m_spriteRenderer.flipX=false;
        }    
    }
}
