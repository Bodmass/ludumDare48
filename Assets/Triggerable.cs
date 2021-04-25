using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerable : MonoBehaviour
{

    protected bool triggered;

    virtual public void TriggerMe(){
        if(triggered)
        {
            //already triggered
            return;
        }
        //trigger me to do something
    }
}
