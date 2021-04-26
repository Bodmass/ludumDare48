using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformNOPARENT : Triggerable
{

    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;

    [SerializeField] private bool requireTrigger; 
    private bool reverse;


    [SerializeField] private float speed = 1.0f;
    private float startTime;
    private float journeyLength;


    void Start()
    {

       Reset();

    }

    private void MoveMe(){

    
        float disCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = disCovered / journeyLength;

        if(!reverse)
        {
        transform.position = Vector3.Lerp(startPos.position, endPos.position, fractionOfJourney);
        }
        else
        {
        transform.position = Vector3.Lerp(endPos.position, startPos.position, fractionOfJourney);
        }

        if((transform.position == endPos.position) && !reverse)
        {
            reverse = true;
            Reset();
        }
        if((transform.position == startPos.position) && reverse)
        {
            reverse = false;
            Reset();
        }
        
    }

    void Reset(){
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPos.position, endPos.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(requireTrigger){
            if(triggered)
            {

                MoveMe();
            }
            else{
                return;
            }
            
        }   
        else{
            MoveMe();
        }     
    }



    public override void TriggerMe()
    {
        Reset();
        triggered = true;     
    }


}
