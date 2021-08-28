using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarSpawner : MonoBehaviour
{

    public GameObject player;
    public GameObject jar;


    public Transform[] spawnPoints;


    public bool jarSpawned;

    public int jarCount;

    public float jarDelayTime;


    

    void Awake()
    {
        jarSpawned = false;
        spawnPoints = new Transform[10];

        for(int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        if ((player.GetComponent<PlayerHealth>().health < 50 || player.GetComponent<PlayerHealth>().fuel < 2) && !jarSpawned && jarCount < 5)
        {

                 jarCount++;
                Instantiate(jar, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                jarSpawned = true;
                StartCoroutine("Timer");
            

    

        }

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(jarDelayTime);
        jarSpawned = false;
    }

}
