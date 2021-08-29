using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditions : MonoBehaviour
{
    int sumOfSingularityHealth;
    bool initialHealthUpdated = false;
    [SerializeField] GameObject nextLevel; 
    // Start is called before the first frame update
    public void UpdateSumHealth(int healthUpdate)
    {
        sumOfSingularityHealth += healthUpdate; 
    }
    public void initialHealthUpdate() { initialHealthUpdated = true; }

    private void Update()
    {
        if (initialHealthUpdated && sumOfSingularityHealth <= 0)
        {
            nextLevel.SetActive(true);  
        }
    }
}
