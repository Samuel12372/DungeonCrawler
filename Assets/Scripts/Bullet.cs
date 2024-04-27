using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 1000f;
    public GameObject bullet;
    public float TimeToLive;
    
    void Start()
    {
        Destroy(gameObject, TimeToLive);
        GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }

    
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "Ogre(Clone)")
        {  
            Debug.Log(other);
            //enemy.dying = true;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if(other.name == "Necromancer(Clone)")
        {  
            Debug.Log(other);
            //enemy.dying = true;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if(other.name == "Pumpkin(Clone)")
        {  
            Debug.Log(other);
            //enemy.dying = true;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        // //top walls
        // {
        //     if(other.name == "Wall4 top") Destroy(gameObject);
        //     if(other.name == "Wall1 top") Destroy(gameObject);
        //     if(other.name == "Secret door") Destroy(gameObject);
        // }
        // //bottom walls
        // {
        //     if(other.name == "Wall bottom") Destroy(gameObject);
        //     if(other.name == "Wall2 bottom") Destroy(gameObject);
        //     if(other.name == "Wall3 bottom") Destroy(gameObject);
        //     if(other.name == "Wall4 bottom") Destroy(gameObject);
        //     if(other.name == "Wall5 bottom") Destroy(gameObject);
        //     if(other.name == "Wall6 bottom") Destroy(gameObject);
        //     if(other.name == "Wall7 bottom") Destroy(gameObject);
        // }
        // //left walls
        // {
        //     if(other.name == "Wall left") Destroy(gameObject);
        //     if(other.name == "Wall2 left") Destroy(gameObject);
        //     if(other.name == "Wall3 left") Destroy(gameObject);
        //     if(other.name == "Wall4 left") Destroy(gameObject);
        // }
        // //right walls
        // {
        //     if(other.name == "Wall right") Destroy(gameObject);
        //     if(other.name == "Wall2 right") Destroy(gameObject);
        //     if(other.name == "Wall3 right") Destroy(gameObject);
        //     if(other.name == "Wall4 right") Destroy(gameObject);
        // }
    }

}
