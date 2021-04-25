using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockade : Triggerable
{

    public override void TriggerMe()
    {
        gameObject.SetActive(false);       
    }
}
