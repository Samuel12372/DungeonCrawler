using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public List<GameObject> Enemies;
    public float maxX;
    public float maxZ;
    public float minX;
    public float minZ;
    public float timeBetweenSpawn;
    private float spawnTime;
    public GameObject player;   

    private float eventTimer = 360f; // 5-minute timer
    private bool eventTriggered = false; 

    //door gameobject
    public GameObject door;
    

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            if(!eventTriggered)
            {
                Spawn();
                spawnTime = Time.time + timeBetweenSpawn;
            }
        }

        if (!eventTriggered)
        {
            eventTimer -= Time.deltaTime;
            if (eventTimer <= 240f)
            { 
                timeBetweenSpawn = 1.5f;
                Debug.Log("1.5");  
            }
            if (eventTimer <= 60f)
            {
                timeBetweenSpawn = 0.5f;  
                Debug.Log("0.5");  
            }
            if (eventTimer <= 0f)
            {
                eventTriggered = true;
                door.gameObject.AddComponent<Rigidbody>();
            }
        }
    }
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minZ, maxZ);

        GameObject e = Instantiate(Enemies[Random.Range(0, Enemies.Count)], new Vector3(randomX, 0.71f, randomY), Quaternion.Euler(45, 0, 0));
        Enemy enemy = e.GetComponent<Enemy>();
        enemy.Target = player.transform;
    }
}

