using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public GameObject startNode;

    public GameObject currentNode;

    public GameObject nextNode;

    public float speed;
    
    public float angleSpeed = 100f;

    // Start is called before the first frame update
    
    void Start()
    {
        currentNode = startNode;
        nextNode = currentNode.GetComponent<MovementMarker>().getNextMarker();
    }

    // To use this script, attach it to the GameObject that you would like to rotate towards another game object.
// After attaching it, go to the inspector and drag the GameObject you would like to rotate towards into the target field.
// Move the target around in the scene view to see the GameObject continuously rotate towards it.
    // The target marker.
    public Transform target;


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

            //rotate towards the new target
            Vector3 targetDirection = nextNode.transform.position - this.transform.position;
            float singleStep = speed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, angleSpeed, 0.0f);
            // Calculate a rotation a step closer to the target and applies rotation to this object
            this.transform.rotation = Quaternion.LookRotation(newDirection);

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
