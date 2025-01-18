using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using System.Linq;
using UnityEditor.Experimental.GraphView;

public class CellsScript : MonoBehaviour
{

    public bool breachedByGerm = false;
    public string deadActions;
    public int spawnUponInfection = 3;
    int j = 0;
    int i = 0;
    bool CELLISALIVE = true;
    public List<GameObject> AllPathogens= new List<GameObject>();
    public GameObject Nucleus;
    public GameObject Rhinovirus;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Nucleus == null && breachedByGerm && Rhinovirus != null && CELLISALIVE == true)
        {

            while (i <= spawnUponInfection && CELLISALIVE == true)
            {
                if (i == spawnUponInfection && CELLISALIVE == true)
                {
                    
                    while (j <= spawnUponInfection && CELLISALIVE == true)
                    {
                        
                        foreach (GameObject Rhinovirus in AllPathogens)
                        {
                            GermMovement RhinovirusScript = Rhinovirus.GetComponent<GermMovement>();
                            RhinovirusScript.stunned = false;

                            
                        }
                        j++;
                    }
                    if (j >= spawnUponInfection)
                    {
                        Destroy(gameObject);
                        CELLISALIVE = false;
                    }

                }
                if (i == spawnUponInfection) continue;
                Debug.Log("running germ infection");
                switch (deadActions)
                {
                case "InfectedByVirus":
                if (Rhinovirus != null)
                {
                       Instantiate(Rhinovirus, transform.position, transform.rotation);
                }
                  break;
                case "KilledByPathogen":
                  Destroy(gameObject);
                  break;
                default:
                  Debug.Log("Error");
                  break;
                }
                AllPathogens = GameObject.FindGameObjectsWithTag("germ").ToList();
                i++;
                
            }
            StartCoroutine(SafeGuard());
        }

    }

    public void OnTriggerEnter2D(Collider2D GermObject)
    {
        if (GermObject.gameObject.CompareTag("germ"))
        {
         breachedByGerm = true;
        }
    }
    public void OnTriggerExit2D(Collider2D GermObject)
    {
        if(GermObject.gameObject.CompareTag("germ"))
        {
         breachedByGerm = false;
        }
        
    }
    IEnumerator SafeGuard()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        Debug.Log("Ran SafeGuard");
    }
}
