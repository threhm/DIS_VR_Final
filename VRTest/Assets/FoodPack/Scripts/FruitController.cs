using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    BoxCollider boxCollider;
    Vector3 fruitPos;

    public GameObject slicedFruit;
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
        Debug.Log("test");
        if (col.CompareTag("sword"))
        {
            Instantiate(slicedFruit, fruitPos, Quaternion.identity);
            ScoreControl.incrementScore();
            Destroy(gameObject);
        }
    }
}
