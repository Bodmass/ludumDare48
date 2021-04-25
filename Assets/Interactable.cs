using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected SphereCollider sphereTrigger;
    [SerializeField] protected float sphereRadius = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        sphereTrigger = gameObject.AddComponent<SphereCollider>();
        sphereTrigger.isTrigger = true;
        sphereTrigger.radius = sphereRadius;
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other) {
        if(other.tag == "Player")
        {
            if(GameObject.FindObjectOfType<ConversationManager>().isTalking){
                return;
            }
            if(Input.GetButtonDown("Interact"))
            {
                Interact();
            }
        }
    }

    void OnTriggerEnter(Collider other) {
    if(other.tag == "Player")
    {
        InteractEnter();
    }
    }


    void OnTriggerExit(Collider other) {
    if(other.tag == "Player")
    {
        InteractExit();
    }
    }

    public virtual void Interact(){
        Debug.Log("Interacted!");
    }

    public virtual void InteractEnter(){

    }

    public virtual void InteractExit(){

    }
}
