using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float m_Speed = 5f;    
    private Rigidbody m_Rigidbody;

    private Transform m_spriteTransform;


    private Vector3 movement;

    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.GetComponentInParent<Transform>();
        m_spriteTransform = GetComponentInChildren<SpriteRenderer>().GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        movement = cameraTransform.TransformDirection(movement);
        movement.y = 0.0f;

        m_Rigidbody.MovePosition(transform.position + movement * m_Speed * Time.deltaTime); 
    }
}
