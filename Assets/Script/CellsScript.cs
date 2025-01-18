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
            if (Nucleus == null && breachedByGerm && Rhinovirus != null)
            {
            int i = 0;
                while(i <= spawnUponInfection)
                {
                    if (i == spawnUponInfection)
                    {
                        GermMovement RhinovirusScript = Rhinovirus.GetComponent<GermMovement>();
                        RhinovirusScript.stunned = false;
                        Destroy(gameObject);

                    }
                Debug.Log("running germ infection");
                    switch (deadActions)
                    {
                        case "InfectedByVirus":
                            if (Rhinovirus != null)
                            {
                            Instantiate(Rhinovirus, transform.position, transform.rotation);
                            Debug.Log(i);
                            }
                            break;
                        case "KilledByPathogen":
                            Destroy(gameObject);
                            break;
                        default:
                            Debug.Log("Error");
                            break;
                    }
                AllPathogens = GameObject.FindGameObjectsWithTag("Germ").ToList();
                i++;
                
                }
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

}
