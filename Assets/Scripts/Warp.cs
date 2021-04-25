using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 warpPos;
    
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player")
        {
            GameObject.FindObjectOfType<playerMovement>().GetComponent<Transform>().position= warpPos;
        }
    }
}
