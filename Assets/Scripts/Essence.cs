using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            other.GetComponent<PlayerEssenceManager>().GainEssence();
            Destroy(this.gameObject);
        }
    }
}
