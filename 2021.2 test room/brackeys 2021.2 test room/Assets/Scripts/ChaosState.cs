using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosState : MonoBehaviour
{
    [SerializeField] GameObject damagebullet;
    [SerializeField] float bulletSpeed; 
    [SerializeField] float maxShootTimer = 2f;
    [SerializeField] float shootTimerDecrease = .5f;
    [SerializeField] float shootTimerDecrease2 = 1f;

     
    float timer; 
    int currentChaosState = 0;
    [Header("Chaos State 1")]
    [SerializeField] List<Transform> chaosOneShooters;

    [Header("Chaos State 2")]
    [SerializeField] List<Transform> chaosTwoShooters;
    [Header("Chaos State 3")]
    [SerializeField] List<Transform> chaosThreeShooters;
    // Start is called before the first frame update  
    void Start()
    {
        timer = maxShootTimer; 
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            PickChaosState();
            timer = maxShootTimer; 
        }
    }

    private void PickChaosState()
    {
        if (currentChaosState == 1) {  ChaosOneFire(); }
        else if (currentChaosState == 2) {  ChaosTwoFire(); }
        else if (currentChaosState == 3) {  ChaosThreeFire(); }
    }

    public void UpdateChaosState(int chaosStateUpdate)
    {
        currentChaosState = chaosStateUpdate; 
    }

    void ChaosOneFire()
    {
        Vector3 randomSpawnLocation = chaosOneShooters[Random.Range(0, chaosOneShooters.Count)].position;
        var bulletClone = Instantiate(damagebullet, randomSpawnLocation , Quaternion.identity);
        bulletClone.GetComponent<Rigidbody>().velocity = Random.insideUnitCircle.normalized * Time.deltaTime * bulletSpeed;
        bulletClone.transform.rotation = Quaternion.LookRotation(bulletClone.GetComponent<Rigidbody>().velocity);
    }

    void ChaosTwoFire()
    {
        
        Vector3 randomSpawnLocation = chaosTwoShooters[Random.Range(0, chaosTwoShooters.Count)].position;
        var bulletClone = Instantiate(damagebullet, randomSpawnLocation, Quaternion.identity);
        bulletClone.GetComponent<Rigidbody>().velocity = Random.insideUnitCircle.normalized * Time.deltaTime * bulletSpeed;
        Debug.Log("chaos2");
        bulletClone.transform.rotation = Quaternion.LookRotation(bulletClone.GetComponent<Rigidbody>().velocity);

        maxShootTimer = shootTimerDecrease;


    }

    void ChaosThreeFire()
    {
        Vector3 randomSpawnLocation = chaosThreeShooters[Random.Range(0, chaosThreeShooters.Count)].position;
        var bulletClone = Instantiate(damagebullet, randomSpawnLocation, Quaternion.identity);
        bulletClone.GetComponent<Rigidbody>().velocity = Random.insideUnitCircle.normalized * Time.deltaTime * bulletSpeed;
        bulletClone.transform.rotation = Quaternion.LookRotation(bulletClone.GetComponent<Rigidbody>().velocity); 

        maxShootTimer = shootTimerDecrease2;  

    }

}
