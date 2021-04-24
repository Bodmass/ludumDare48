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

    void Start(){
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(){
        isGrounded = true;
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
        m_Rigidbody.AddForce(jump * m_jumpForce, ForceMode.Impulse);
        isGrounded = false;
        }
    }

}