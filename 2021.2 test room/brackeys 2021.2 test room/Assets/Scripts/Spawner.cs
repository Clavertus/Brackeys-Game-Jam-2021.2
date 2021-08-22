using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float initialSpawnTime;
    [SerializeField] GameObject ObjectToSpawn; 
    float spawnTimer = 3;
    void Start()
    {
        spawnTimer = initialSpawnTime; 
    }

    void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime; 
        }
        else
        {
            Spawn(); 
            spawnTimer = initialSpawnTime; 
        }
    }

    void Spawn()
    {
        Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);  
    }
}
