using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public GameObject startNode;

    public GameObject currentNode;

    public GameObject nextNode;

    public float speed;
    
    

    // Start is called before the first frame update
    
    void Start()
    {
        currentNode = startNode;
        nextNode = currentNode.GetComponent<MovementMarker>().getNextMarker();
    }

    // Update is called once per frame
    void Update()
    {
        //If we are close to the next node then move to another node
        if((((gameObject.transform.position.x - nextNode.transform.position.x) <= 0.4 ) && ((gameObject.transform.position.x - nextNode.transform.position.x) >= -0.4))
         &&
        (((gameObject.transform.position.y - nextNode.transform.position.y) <= 0.4 ) && ((gameObject.transform.position.y - nextNode.transform.position.y) >= -0.4)) 
        &&
        (((gameObject.transform.position.z - nextNode.transform.position.z) <= 0.4 ) && ((gameObject.transform.position.z - nextNode.transform.position.z) >= -0.4))) {
            currentNode = nextNode;
            nextNode = currentNode.GetComponent<MovementMarker>().getNextMarker();
            speed = currentNode.GetComponent<MovementMarker>().speed;
            //Debug.Log("Stuck here");
        } else {
            Vector3 difference = nextNode.transform.position - gameObject.transform.position;
            difference.Normalize();
            Vector3 scalar = new Vector3(speed, speed, speed);
            difference.Scale(scalar);
            gameObject.transform.position = gameObject.transform.position + difference;
            //Debug.Log("Moving");
        }
    }
}
