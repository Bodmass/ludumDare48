using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skyspin : MonoBehaviour
{
    [SerializeField] private Vector3 dirToSpin;
    [SerializeField] private float spinSpeed;


    private void Update() { 
        transform.Rotate((dirToSpin * Time.deltaTime));
    }
}
