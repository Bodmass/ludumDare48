using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Triggerable
{

    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;

    [SerializeField] private bool requireTrigger; 
    private bool reverse;


    [SerializeField] private float speed = 1.0f;
    private float startTime;
    private float journeyLength;

    
    // Start is called before the first frame update
    void Start()
    {

        // GameObject[] children = GetComponentsInChildren<GameObject>();
        // foreach(GameObject go in children)
        // {
        //     if(go.name=="start" || go.name=="end")
        //     {
        //         go.GetComponent<MeshRenderer>().enabled = false;
        //     }

        //     if(go.name=="start")
        //     {
        //         Debug.Log("Found start!!!");
        //         startPos = go.transform.position;
        //     }
        //     if(go.name=="end")
        //     {
        //         endPos = go.transform.position;
        //     }
        // }

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

    private void OnCollisionStay(Collision other) {
        Vector3 test = transform.position;
        if(transform.position.y < test.y)
        {
            Debug.Log("Moving Down");
        }
        if(other.collider.tag == "Player")
        {
            other.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.collider.tag == "Player")
        {
            other.collider.transform.SetParent(null);
        }
    }


    public override void TriggerMe()
    {
        Reset();
        triggered = true;     
    }


}
