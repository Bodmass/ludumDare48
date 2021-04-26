using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : Interactable
{
    [SerializeField] private GameObject chatBubble;
    private GameObject chatBubbleInstance;
    public override void Interact()
    {
        Debug.Log("Triggered Conversation!");
        GetComponent<Conversation>().TriggerConversation();
    }

    public override void InteractEnter()
    {
        chatBubbleInstance = GameObject.Instantiate(chatBubble, this.transform);

    }

    public override void InteractExit()
    {
        if(chatBubbleInstance != null)
        {
            Destroy(chatBubbleInstance);
        }
    }
}
