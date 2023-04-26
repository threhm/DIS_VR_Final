using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartApple : MonoBehaviour
{
    BoxCollider boxCollider;
    Vector3 fruitPos;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        fruitPos = transform.position;
        boxCollider.isTrigger = true;
        boxCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        
        if (col.CompareTag("sword"))
        {
            GameObject.Find("XR Origin").GetComponent<PlayerMover>().speed = 0.05f;
            Destroy(this.gameObject);
        }
    }
}