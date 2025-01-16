using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> AllSpawners = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        AllSpawners = GameObject.FindGameObjectsWithTag("spawner").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < AllSpawners.Count; i++)
        {
            Spawner Spawner = AllSpawners[i].GetComponent<Spawner>();
            if (AllSpawners != null)
            {
                Spawner.waveEnd = false;
            }
        }
    }
/*
    */
}
