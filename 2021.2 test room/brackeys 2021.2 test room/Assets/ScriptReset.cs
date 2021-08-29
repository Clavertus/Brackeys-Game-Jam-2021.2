using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptReset : MonoBehaviour
{
    public LevelManager levelManager;

    public bool rebooting;

    void Start()
    {
        rebooting = false;
    }
    void Update()
    {
        if (levelManager.levelMusic.timeSamples > 6264000 && !rebooting)
        {
            rebooting = true;
            levelManager.levelMusic.Stop();
            levelManager.beatStarted = false;
            levelManager.StopCoroutine("NewUpdate");
            levelManager.gameObject.SetActive(false);
            Invoke("Reboot", .5f);
            
        }

    }

    void Reboot()
    {
        levelManager.gameObject.SetActive(true);


    }

}
