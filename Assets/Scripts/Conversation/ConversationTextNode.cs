using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTextNode : ConversationNode
{
    [SerializeField] protected string text_;

    public string text{
        get {return text_;}
    }

    public override void UseNode()
    {
        //
    }
}
