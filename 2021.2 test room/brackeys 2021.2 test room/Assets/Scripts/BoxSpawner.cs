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
    [SerializeField] int spawnExtraBoxesAtCount = 10;
    [SerializeField] int extraBoxesToSpawn = 5;
    [SerializeField] float maxTimeBetweenSpawns = 5f;
    [SerializeField] int maxBoxes = 50;
    [SerializeField] int maxOrbs = 10; 
    float betweenSpawnsTimer; 
    float timer;
    string[] damageBoxTags = { "Untagged", "c", "cc" };

    LevelManager levelManager; 

    public float gravAngle;

    int currentOrbCount; 
    int currentBoxCount;  
    int sumOfSingularitiesHealth; 
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("levelManager").GetComponent<LevelManager>();
        timer = maxSpawnTimer;
        betweenSpawnsTimer = maxTimeBetweenSpawns; 
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

        betweenSpawnsTimer -= Time.deltaTime; 
        if(betweenSpawnsTimer <= 0)
        {
            SpawnBox();
        }
    }

   

    public void HealthSum(int singularityHealthCange)
    {
        sumOfSingularitiesHealth += singularityHealthCange;
    }

    void SpawnBox()
    {
        if(currentBoxCount >= maxBoxes) { return;  }
        Vector3 randomSpawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)].position;

        var damageBoxInstance = Instantiate(damageBox, randomSpawnLocation, Quaternion.Euler(0,0,180));
        damageBoxInstance.transform.GetChild(0).GetChild(1).GetComponent<BoxArrow>().mat.SetFloat(
            damageBoxInstance.transform.GetChild(0).GetChild(1).GetComponent<BoxArrow>().rotation,
            gravAngle);

        betweenSpawnsTimer = maxTimeBetweenSpawns; 
        /*
        string randomBoxTag = damageBoxTags[Random.Range(0, damageBoxTags.Length)];
        damageBoxInstance.tag = randomBoxTag; 
        */
        currentBoxCount = FindObjectsOfType<DamageBox>().Length;
        Debug.Log(currentBoxCount);
        if (currentBoxCount < spawnExtraBoxesAtCount)
        {
            StartCoroutine(SpawnExtraBoxes());
        }

    }

    void SpawnOrb()
    {
        if (currentOrbCount >= maxOrbs) { return; } 

        Vector3 randomSpawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)].position;
        var healingOrbInstance = Instantiate(healingOrb, randomSpawnLocation, Quaternion.Euler(0,0,180));
        healingOrbInstance.transform.GetChild(0).GetChild(1).GetComponent<BoxArrow>().mat.SetFloat(
            healingOrbInstance.transform.GetChild(0).GetChild(1).GetComponent<BoxArrow>().rotation,
            gravAngle);


         
        currentOrbCount = FindObjectsOfType<HealingOrb>().Length;
    }
    private IEnumerator SpawnExtraBoxes()
    {

        for (int i = 0; i < extraBoxesToSpawn; i++)
        {
            yield return new WaitForSeconds(maxSpawnTimer);
            SpawnBox(); 
        }
        betweenSpawnsTimer = maxTimeBetweenSpawns;

    }
}
