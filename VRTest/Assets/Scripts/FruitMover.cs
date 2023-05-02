using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitMover : MonoBehaviour
{

    public float xMove = 1f;

    public float yMove = 1f;

    public float zMove = 1f;

    public float xSpeed = 0.02f;
    public float ySpeed = 0.02f;
    public float zSpeed = 0.02f;

    private float origX;
    private float origY;
    private float origZ;
    private float maxX;
    private float minX;
    private float maxY;
    private float minY;
    private float maxZ;
    private float minZ;

    public bool movingX;
    public bool movingY;
    public bool movingZ;
    // Start is called before the first frame update
    void Start()
    {
        origX = transform.position.x;
        origY = transform.position.y;
        origZ = transform.position.z;

        maxX = origX + xMove;
        minX = origX - xMove;
        maxY = origY + yMove;
        minY = origY - yMove;
        maxZ = origZ + zMove;
        minZ = origZ - zMove;
    }

    // Update is called once per frame
    void Update()
    {
        float newX;
        float newY;
        float newZ;
        if(movingX) {
            newX = transform.position.x + xSpeed;
            if(transform.position.x > maxX) {
                movingX = false;
            }
        } else {
            newX = transform.position.x - xSpeed;
            if(transform.position.x < minX) {
                movingX = true;
            }
        }
        if(movingY) {
            newY = transform.position.y + ySpeed;
            if(transform.position.y > maxY) {
                movingY = false;
            }
        } else {
            newY = transform.position.y - ySpeed;
            if(transform.position.y < minY) {
                movingY = true;
            }
        }
        if(movingZ) {
            newZ = transform.position.z + zSpeed;
            if(transform.position.z > maxZ) {
                movingZ = false;
            }
        } else {
            newZ = transform.position.z - zSpeed;
            if(transform.position.z < minZ) {
                movingZ = true;
            }
        }

        transform.position = new Vector3(newX, newY, newZ);
    }
}
