using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject gravityBullet;
    public GameObject freezeBullet;

    public GameObject currentBullet;

    public GameObject capsule;

    public Material freezeMat;
    public Material gravMat;

    public AudioClip gravSFX;
    public AudioClip freezeSFX;
    public AudioClip clang1SFX;
    public AudioClip clang2SFX;
    public AudioClip landingSFX;
    public AudioClip landing2SFX;
    public AudioClip pickupSFX;
    public AudioClip gravityswitchSFX;

    public JarSpawner jarSpawner;


    public AudioManager audioManager;
    
    public void PlaySound(AudioClip sfx)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        if(sfx == landingSFX || sfx == landing2SFX)
        {
            source.volume = 0.2f;
        }
        source.clip = sfx;
        source.Play();
        Destroy(source, source.clip.length);

    }

    public string cb;

    void Start()
    {
        currentBullet = gravityBullet;
        cb = "gravity";
    }

    void Update()
    {


        if (Input.GetKeyDown("q") && cb == "gravity")
        {
            currentBullet = freezeBullet;
            cb = "freeze";
            capsule.GetComponent<MeshRenderer>().material = freezeMat;
        } else if (Input.GetKeyDown("q") && cb == "freeze")
            {
                currentBullet = gravityBullet;
                cb = "gravity";
            capsule.GetComponent<MeshRenderer>().material = gravMat;

        }






    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "jar")
        {
            Destroy(other.gameObject);

            jarSpawner.jarCount--;

            GetComponent<PlayerHealth>().fuel = GetComponent<PlayerHealth>().maxFuel;
            GetComponent<PlayerHealth>().health = GetComponent<PlayerHealth>().maxHealth;
            GetComponent<PlayerManager>().PlaySound(GetComponent<PlayerManager>().pickupSFX);
        }
    }


}
