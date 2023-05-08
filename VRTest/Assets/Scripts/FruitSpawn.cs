using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    public float spawnRate = 1f;
    public bool startShooting = true;

    public GameObject fruitPrefab;

    Vector3 cannonPos;
    public float magnitude = 5.0f;

    private float lastSpawnTime = 0;

    void Start()
    {
        cannonPos = transform.parent.transform.position;
    }

    void Update()
    {
        if (startShooting && lastSpawnTime + 1 / spawnRate < Time.time)
        {
            lastSpawnTime = Time.time;
            GameObject fruit = Instantiate(fruitPrefab, transform.position, Quaternion.identity);
            Shoot(fruit.GetComponent<Rigidbody>());
        }
    }

    private void Shoot(Rigidbody rg)
    {
        rg.WakeUp();
        Vector3 fireDirection = transform.position - cannonPos;
        Vector3 movement = new Vector3(fireDirection.x * magnitude, fireDirection.y * magnitude, fireDirection.z * magnitude);
        rg.velocity = movement;
    }
}
