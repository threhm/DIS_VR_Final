using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float top;

    public float bottom;

    public bool movingUp;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movingUp) {
            gameObject.transform.position = new Vector3(transform.position.x + speed, gameObject.transform.position.y, gameObject.transform.position.z);
            if(gameObject.transform.position.x > top) {
                movingUp = false;
            }
        } else {
            gameObject.transform.position = new Vector3(transform.position.x - speed, gameObject.transform.position.y, gameObject.transform.position.z);
            if(gameObject.transform.position.x < bottom) {
                movingUp = true;
            }
        }
    }
}
