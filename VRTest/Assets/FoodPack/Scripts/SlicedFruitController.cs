using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicedFruitController : MonoBehaviour
{
    public float sliceForce = 100f;
    public float fallingTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            Rigidbody sliceRb = child.gameObject.GetComponent<Rigidbody>();
            rgUpdate(sliceRb);
        }
        Destroy(gameObject, fallingTime);

    }

    /**
     * Enable rigidbody and give it gravity/extra force to have the falling effects
     * @param {rigidbody} the rigidbody to set
     */
    private void rgUpdate(Rigidbody rigidbody)
    {
        rigidbody.WakeUp();
        rigidbody.AddForce(Random.insideUnitCircle * sliceForce);
    }
}
