using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationEssenceNode : ConversationTextNode
{
    private bool obtained_ = false;

    public bool obtained{
        get {return obtained_;}
    }
    [SerializeField] private int EssenceMaxToAdd = 3;
    override public void UseNode()
    {
        GameObject.FindObjectOfType<PlayerEssenceManager>().IncreaseEssenceCap(EssenceMaxToAdd);
        obtained_ = true;
    }
}
