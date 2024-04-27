using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject SecretDoor1;
    //public List<AudioClip> DoorClips;
    //public AudioClip Door1;
    //public AudioClip Door2;
    public Transform Enemy;
    void Start()
    {
        //AudioSource sfx = GetComponent<AudioSource>();
        //sfx.pitch = UnityEngine.Random.Range(0.95f,1.05f);
        //sfx.clip = DoorClips[UnityEngine.Random.Range(0,DoorClips.Count)];
    }
    void Update()
    {
        if (Enemy == null)
        {
            //AudioSource sfx = GetComponent<AudioSource>();
            //SecretDoor1.SetActive(false);
            //sfx.Play();
        }
        else
        {
            SecretDoor1.SetActive(true);
        }
    }

}
