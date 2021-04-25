using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerShadow : MonoBehaviour
{

    float difference = 10f;

    RaycastHit hit;
    private Transform player;
    void Start()
    {
        player = GameObject.FindObjectOfType<playerMovement>().transform;
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        Vector3 differenceVector = new Vector3(player.transform.position.x, player.transform.position.y - difference, player.transform.position.z);

        if(Physics.Linecast(player.transform.position, differenceVector, out hit))
        {
            
        newPos.y = hit.transform.position.y;
        }
        transform.position = newPos;
    }
}
