using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Target;
    public float movementSpeed;
    public float DamageAmount = 1f;
    public List<AudioClip> explosions;
    private AudioSource sfx;
    public bool dying = false;
    void Start()
    {
        sfx = GetComponent<AudioSource>(); 
    }
    void Update()
    {
        if(dying)
        {
            //these dont work figure out why
            sfx.clip = explosions[Random.Range(0,1)];
            sfx.Play();
            Destroy(gameObject);
        }
        transform.position = Vector3.Lerp(transform.position, Target.position, movementSpeed * Time.deltaTime);

        
    }
}
