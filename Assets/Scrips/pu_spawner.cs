﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pu_spawner : MonoBehaviour
{

    public float delay, destroyDelay, speed, difficultyIncrease;
    public int limit;
    public float minTime = 10f;
    public float maxTime = 20f;
    public Transform[] positions;
    private int delta = 0;
    public GameObject[] powers;

    public bool poderes = false;
    int judge = 1;
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        
        judge++;
        int prefab = Random.Range(0, powers.Length); 
        int posSpawn = Random.Range(0, positions.Length);
        if (judge%3==0)
        {
            GameObject x = Instantiate<GameObject>(powers[prefab], positions[posSpawn].transform.position, powers[prefab].transform.rotation);
            x.GetComponent<Obstacle>().speed = speed;
            Destroy(x, destroyDelay);
           
        }
        yield return new WaitForSeconds(delay);
        delay = Random.Range(minTime, maxTime);
        //Debug.Log(delay);

            if (delta < limit)
            {
                speed += difficultyIncrease;
                delta++;
            }
            StartCoroutine(Spawn());
       /* }*/
        

        
    }
    
        
    
}

