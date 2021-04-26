using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    [SerializeField] private Triggerable[] triggerable;
    bool Activated = false;

    private Vector3 start;
    private Vector3 end;
    [SerializeField] private float speed = 1.0f;
    private float startTime;
    private float journeyLength;
    [SerializeField] private Transform innerSwitch;
    // Start is called before the first frame update
    void Start()
    {
        start = new Vector3(-0.43060112f,0.104000002f,0.478653908f);
        end = new Vector3(-0.43060112f,-0.145999998f,0.478653908f);
        if(triggerable == null)
        {
            this.gameObject.SetActive(false);
        }
    }

    void ActivateSwtich()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(start, end);
        foreach(Triggerable trig in triggerable)
        {
            trig.TriggerMe();
        }
    }
    
    void OnTriggerEnter(Collider other) {
        if(!Activated && other.tag == "Player")
        {
            Activated = true;
            ActivateSwtich();
        }
    }

    void Update()
    {
        if(Activated)
        {

        float disCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = disCovered / journeyLength;
        innerSwitch.localPosition = Vector3.Lerp(start, end, fractionOfJourney);
        
        if(innerSwitch.localPosition == end)
        {
            Destroy(this);
        }
        }
        


    }
}
