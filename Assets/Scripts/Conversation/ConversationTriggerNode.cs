using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTriggerNode : ConversationTextNode
{
    [SerializeField] private Triggerable[] triggerable;
    bool activated_ = false;

    public bool activated{
        get { return activated_;}

    }

    override public void UseNode()
    {
        if(activated)
        {
            return;
        }
        foreach(Triggerable trig in triggerable)
        {
            trig.TriggerMe();
            activated_ = true;
        }
    }


}
