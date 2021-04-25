using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Talk))]
public class Conversation : MonoBehaviour
{
    [SerializeField] private ConversationNode[] conversation;

    public ConversationNode[] conversationNodes{
        get {return conversation;}
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerConversation()
    {
        Debug.Log("TriggerConversation2");
        GameObject.FindObjectOfType<ConversationManager>().ParseConversation(this);
    }
}
