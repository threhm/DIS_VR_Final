using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public GameObject startNode;

    public GameObject currentNode;

    public GameObject nextNode;

    public float speed;

    //Can be changed to make the player turn faster or slower
    public float turnMagnitude = 10f;
    
    //public float angleSpeed;

    //private Vector3 targetDirection;
   // private float singleStep;
    //private Vector3 newDirection;

    //public float turnTimer;
    //private float timer;
    //private bool turning;

    //private Quaternion neededRotation;

    // Start is called before the first frame update
    
    void Start()
    {
        currentNode = startNode;
        nextNode = currentNode.GetComponent<MovementMarker>().getNextMarker();
        //turning = false;
        //timer = turnTimer;
    }

    // To use this script, attach it to the GameObject that you would like to rotate towards another game object.
    // After attaching it, go to the inspector and drag the GameObject you would like to rotate towards into the target field.
    // Move the target around in the scene view to see the GameObject continuously rotate towards it.
    // The target marker.
    public Transform target;


    // Update is called once per frame
    void Update()
    {

        //Turn the player towards the next node
        Quaternion neededRotation = Quaternion.LookRotation((nextNode.transform.position - this.transform.position));    
        transform.rotation = Quaternion.RotateTowards(transform.rotation, neededRotation, Time.deltaTime * turnMagnitude);   

        //If we are close to the next node then move to another node otherwise keep moving the player towards the node that they're already going towards
        if((((gameObject.transform.position.x - nextNode.transform.position.x) <= 0.4 ) && ((gameObject.transform.position.x - nextNode.transform.position.x) >= -0.4))
         &&
        (((gameObject.transform.position.y - nextNode.transform.position.y) <= 0.4 ) && ((gameObject.transform.position.y - nextNode.transform.position.y) >= -0.4)) 
        &&
        (((gameObject.transform.position.z - nextNode.transform.position.z) <= 0.4 ) && ((gameObject.transform.position.z - nextNode.transform.position.z) >= -0.4))) {
            currentNode = nextNode;
            nextNode = currentNode.GetComponent<MovementMarker>().getNextMarker();
            speed = currentNode.GetComponent<MovementMarker>().speed;
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
