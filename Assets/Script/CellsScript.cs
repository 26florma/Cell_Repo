using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CellsScript : MonoBehaviour
{

    public bool breachedByGerm = false;
    public string deadActions;
    public int spawnUponInfection = 3;

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

                for (int i = 0; i < spawnUponInfection; i++)
                {
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
                if(i == spawnUponInfection)
                {
                    GermMovement RhinovirusScript = Rhinovirus.GetComponent<GermMovement>();
                    RhinovirusScript.stunned = false;
                    Destroy(gameObject);
                }

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
