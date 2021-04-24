using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCameraBillboarding : MonoBehaviour
{

    void FixedUpdate() {
        
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
        Camera.main.transform.rotation * Vector3.up);

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
