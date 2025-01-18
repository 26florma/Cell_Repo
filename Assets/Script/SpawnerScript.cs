
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Diagnostics;

public class Spawner : MonoBehaviour
{
    public int numberToSpawn = 3;
    public float spawnRate = 1.2f;
    public GameObject ObjectToSpawn;
    public bool waveEnd = true;
    public bool startSpawning = true;
    public int ObjectsSpawned;
    void Update()
    {
            if (waveEnd == true)
            {
                UnityEngine.Debug.Log("Runing else");
                waveEnd = true;
                StopCoroutine(StartSpawningPathogens());
            }
            if (waveEnd == false)
            {
                UnityEngine.Debug.Log("Running Coroutine");
                StartCoroutine(StartSpawningPathogens());
            }
            if(numberToSpawn < ObjectsSpawned)
            {
            waveEnd = true;
            StopCoroutine(StartSpawningPathogens());
            StopCoroutine(StartDelay());
            startSpawning = false;
            }
    }
    IEnumerator StartSpawningPathogens()
    {
        while (waveEnd == false)
        {
            yield return new WaitForSeconds(spawnRate);
            if (ObjectToSpawn != null && startSpawning && numberToSpawn != ObjectsSpawned)
            {
                Instantiate(ObjectToSpawn, transform.position, transform.rotation);
                UnityEngine.Debug.Log("spawning" + ObjectToSpawn);
                ObjectsSpawned++;
                startSpawning = false;
                StartCoroutine(StartDelay());
                StopCoroutine(StartSpawningPathogens());
            }
            if(numberToSpawn == ObjectsSpawned)
            {
                StopCoroutine(StartSpawningPathogens());
                StopCoroutine(StartDelay());
            }
        }
    }
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(spawnRate);
        if(numberToSpawn != ObjectsSpawned)
        {
            startSpawning = true;
            StartCoroutine(StartSpawningPathogens());
            StopCoroutine(StartDelay());
        }
        if(numberToSpawn == ObjectsSpawned)
        {
            StopCoroutine(StartSpawningPathogens());
            StopCoroutine(StartDelay());
        }
    }

} 
