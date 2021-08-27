using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] GameObject DamageBox;
    [SerializeField] GameObject HealingOrb;
    [SerializeField] List<Transform> spawnLocations; 
    int currentBoxCount; 
    int minimumBoxes;
    int sumOfSingularitiesHealth; 
    // Start is called before the first frame update
    void Start()
    {
        currentBoxCount = FindObjectsOfType<DamageBox>().Length;  
    }

    // Update is called once per frame
    void Update()
    {
        if(currentBoxCount < sumOfSingularitiesHealth)
        {
            SpawnBox(); 
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

        Instantiate(DamageBox, randomSpawnLocation, Quaternion.Euler(0,0,180));   

        currentBoxCount++; 
    }
}
