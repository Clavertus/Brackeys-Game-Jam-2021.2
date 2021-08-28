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

    LevelManager levelManager;

    public float gravAngle;

    int currentOrbCount; 
    [SerializeField] int currentBoxCount; 
    [SerializeField] int sumOfSingularitiesHealth; 
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("levelManager").GetComponent<LevelManager>();
        timer = maxSpawnTimer; 
        currentBoxCount = FindObjectsOfType<DamageBox>().Length;
        currentOrbCount = FindObjectsOfType<HealingOrb>().Length; 

    }

    // Update is called once per frame
    void Update()
    {
        switch (levelManager.currentGrav)
        {
            case 0:
                gravAngle = 0;
                break;

            case 1:
                gravAngle = -90;
                break;

            case 2:
                gravAngle = -180;
                break;

            case 3:
                gravAngle = -270;
                break;


        }
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
        damageBoxInstance.transform.GetChild(0).GetChild(1).GetComponent<BoxArrow>().mat.SetFloat(
            damageBoxInstance.transform.GetChild(0).GetChild(1).GetComponent<BoxArrow>().rotation,
            gravAngle);
            

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
        healingOrbInstance.transform.GetChild(0).GetChild(1).GetComponent<BoxArrow>().mat.SetFloat(
            healingOrbInstance.transform.GetChild(0).GetChild(1).GetComponent<BoxArrow>().rotation,
            gravAngle);


        currentOrbCount = FindObjectsOfType<HealingOrb>().Length;
    }
    
}
