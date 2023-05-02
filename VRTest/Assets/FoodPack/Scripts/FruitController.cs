using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FruitController : MonoBehaviour
{
    BoxCollider boxCollider;
    Rigidbody appleRigidbody;

    Vector3 fruitPos;

    public float magnitude = 1.0f;
    public int shotAngle = 50;
    public int xDirection = -1;
    public int yDirection = 0;
    public int zDirection = 0;

    public GameObject slicedFruit;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        appleRigidbody = GetComponent<Rigidbody>();
        fruitPos = transform.position;
        boxCollider.isTrigger = true;
        boxCollider.enabled = true;
        SetupRb(appleRigidbody);
    }

    private void SetupRb(Rigidbody rg)
    {
        GetComponent<Rigidbody>().WakeUp();
        Vector3 movement = Quaternion.AngleAxis(shotAngle, new Vector3(xDirection, yDirection, zDirection)) * new Vector3(magnitude, magnitude, magnitude);
        rg.velocity = movement;
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("test");
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
