using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CellsScript : MonoBehaviour
{

    public bool breachedByGerm = false;
    public bool cellIsAlive = true;
    public string deadActions;
    public int spawnUponInfection = 3;

    public GameObject Pathogen;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (breachedByGerm && Pathogen != null)
        {

            for (int i = 0; i < spawnUponInfection; i++)
            {
                Debug.Log("running germ infection");
                if (cellIsAlive == false)
                {
                    switch (deadActions)
                    {
                        case "InfectedByVirus":
                            if (Pathogen != null)
                            {
                                Instantiate(Pathogen, transform.position, transform.rotation);
                            }
                            break;
                        case "KilledByPathogen":
                            Destroy(gameObject);
                            break;
                        default:
                            Debug.Log("Error");
                            break;
                    }
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D GermObject)
    {
        if(GermObject.gameObject.CompareTag("germ") && Pathogen == null)
        {
         Pathogen = GermObject.gameObject;
         breachedByGerm = true;
        }
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Nucl"))
        {
            cellIsAlive = true;
        }
        else
        {
            cellIsAlive = false;
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
