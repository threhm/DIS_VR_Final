using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMarker : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 0.05f;

    public GameObject nextMarker;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getNextMarker() {
        return nextMarker;
    }
}
