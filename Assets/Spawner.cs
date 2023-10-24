using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
   
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

        int rando = Random.Range(0, objectsToSpawn.Length);
        GameObject spawnedObject = Instantiate(objectsToSpawn[rando], transform.position, Quaternion.identity);

        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left*moveSpeed;
        

    }

   
}



