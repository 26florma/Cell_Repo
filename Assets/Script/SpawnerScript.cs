
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
    void Update()
    {
        for (int i = 0; i > numberToSpawn; i++)
        {
            if (waveEnd == false)
            {
                StartCoroutine(StartSpawningPathogens());
            }
            else
            {
                waveEnd = true;
            }
        }

    }
    IEnumerator StartSpawningPathogens()
    {
        yield return new WaitForSeconds(spawnRate);
        if (ObjectToSpawn != null)
        {
            Instantiate(ObjectToSpawn, transform.position, transform.rotation);
        }
        else
        {
            UnityEngine.Debug.Log("ObjectToSpawn not set yet");
        }
    }
} 
