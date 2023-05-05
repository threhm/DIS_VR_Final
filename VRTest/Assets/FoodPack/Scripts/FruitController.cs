using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FruitController : MonoBehaviour
{
    SphereCollider boxCollider;
    Rigidbody appleRigidbody;

    Vector3 fruitPos;

    public GameObject slicedFruit;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<SphereCollider>();
        appleRigidbody = GetComponent<Rigidbody>();
        fruitPos = transform.position;
        boxCollider.isTrigger = true;
        boxCollider.enabled = true;
    }

    void Update()
    {
        fruitPos = transform.position;
    }

    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log("test");
        if (col.CompareTag("sword")) // Sliced fruits
        {
            Instantiate(slicedFruit, fruitPos, Quaternion.identity);
            ScoreControl.incrementScore();
            UIManager.UpdateScore();
            Destroy(gameObject);
        }
        else if (col.CompareTag("Ground")) // Destroy unsliced fruits
        {
            Destroy(gameObject);
        }
    }
}
