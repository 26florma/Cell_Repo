using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.linq;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> AllSpawners = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        AllSpawners = GameObject.FindGameObjectWithTag("spawner").toList();
        Spawner SpawnerScript = AllSpawners.gameObject.GetComponent<Spawner>();
        if(AllSpawners != null && )
        {
        Spawner.waveEnd = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
/* 
//this code is for the spawners
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.linq;
public class Spawner : MonoBehaviour
{
    public int numberToSpawn = 3;
    public float spawnRate = 1.2;
    public GameObject ObjectToSpawn;
    public bool waveEnd = true 
    void Update()
    {
     if(int i = 0; i > numberToSpawn; i++ && waveEnd == false)
     {
     StartCorutine(StartSpawningPathogens());
     }
     else
     {
     waveEnd = true;
     }
    }
    IEnumerator StartSpawningPathogens()
    {
     yield new WaitForSeconds(spawnRate);
     if(ObjectToSpawn != null)
     {
     instantiate(ObjectToSpawn,transform.position,transform.rotation);
     }
     else
     {
     debug.log("ObjectToSpawn not set yet");
     }
    }
*/
}
