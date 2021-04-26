using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPushback : MonoBehaviour
{
    [SerializeField] private float pushForce = 5.0f;
    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Player"){
            
            Vector3 direction = (transform.position - other.transform.position).normalized;
            other.collider.GetComponent<Rigidbody>().AddForce(direction * pushForce, ForceMode.Impulse);
        }
    }
}
