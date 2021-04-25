using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour
{
    ParticleSystem m_particleSystem;
    ParticleSystem.EmissionModule main;
    bool Triggered = false;

    [SerializeField] private float fadingScale = 2.0f;
    private float fading;

    private void Start() {
        m_particleSystem = GetComponentInChildren<ParticleSystem>();
        fading = main.rateOverTime.constant;
    }



    void OnTriggerEnter(Collider other)
    {
        if(Triggered)
        {
            return;
        }
        if(other.tag == "Player")
        {
        Triggered = true;
        Debug.Log("TRIGGERED ESSENCE");

        }
    }

    private void Update() {
        if(Triggered)
        {
            fading -=  fadingScale * Time.deltaTime;

            //main.rateOverTime.constant  = fading;
        }
    }
}
