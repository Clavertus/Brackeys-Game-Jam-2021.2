using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] GameObject damageBox;
    [SerializeField] GameObject healingOrb;
    [SerializeField] List<Transform> spawnLocations;
    [SerializeField] int sumThresholdToSpawnOrbs; 
    [SerializeField] float maxSpawnTimer = 2f;
    float timer;
    string[] damageBoxTags = { "Untagged", "c", "cc" };

    int currentOrbCount; 
    [SerializeField] int currentBoxCount; 
    [SerializeField] int sumOfSingularitiesHealth; 
    // Start is called before the first frame update
    void Start()
    {
        timer = maxSpawnTimer; 
        currentBoxCount = FindObjectsOfType<DamageBox>().Length;
        currentOrbCount = FindObjectsOfType<HealingOrb>().Length; 

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (currentBoxCount < sumOfSingularitiesHealth && timer <= 0)
        {
            SpawnBox();
            timer = maxSpawnTimer;
        }
        if
            (sumOfSingularitiesHealth < sumThresholdToSpawnOrbs && currentOrbCount < sumOfSingularitiesHealth && timer <= 0) 
        {
            SpawnOrb();
            timer = maxSpawnTimer;
              
        }
    }

    public void HealthSum(int singularityHealthCange)
    {
        sumOfSingularitiesHealth += singularityHealthCange;
        Debug.Log(sumOfSingularitiesHealth); 
    }

    void SpawnBox()
    {
        Vector3 randomSpawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)].position;

        var damageBoxInstance = Instantiate(damageBox, randomSpawnLocation, Quaternion.Euler(0,0,180));

        /*
        string randomBoxTag = damageBoxTags[Random.Range(0, damageBoxTags.Length)];
        damageBoxInstance.tag = randomBoxTag; 
        */
        currentBoxCount = FindObjectsOfType<DamageBox>().Length;

    }

    void SpawnOrb()
    {
        Vector3 randomSpawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)].position;
        var healingOrbInstance = Instantiate(healingOrb, randomSpawnLocation, Quaternion.identity);
        currentOrbCount = FindObjectsOfType<HealingOrb>().Length;
    }
    
}
