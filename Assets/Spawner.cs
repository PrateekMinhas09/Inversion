using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnRate = 2.0f;  // Time between spawns
    public float moveSpeed = 5.0f; // Speed of the spawned object
    private float nextSpawnTime = 0.0f;

    private void Update()
    {
        // Check if it's time to spawn a new object
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnObject()
    {
        // Create a new instance of the object to spawn
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);

        // Make the spawned object move to the left
        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
        else
        {
            Debug.LogWarning("Spawned object doesn't have a Rigidbody2D component.");
        }
    }
}


