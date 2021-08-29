using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditions : MonoBehaviour
{
    int sumOfSingularityHealth;
    bool initialHealthUpdated = false;
    [SerializeField] GameObject nextLevel;
    // Start is called before the first frame update
    bool soundNotPlayed;

    void Awake()
    {
        soundNotPlayed = true;
    }



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
            if (soundNotPlayed)
            {
                GameObject.FindGameObjectWithTag("levelManager").GetComponent<LevelManager>().levelMusic.volume = 0;

                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().PlaySound(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().endLevelSFX);
                soundNotPlayed = false;
            }
 

        }
    }
}
