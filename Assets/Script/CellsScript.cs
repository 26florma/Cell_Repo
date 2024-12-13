using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsScript : MonoBehaviour
{

    public bool breachedByGerm = false;
    public bool cellIsAlive = true;
    public string deadActions;

    public GameObject Pathogen;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       if(cellIsAlive == false)
       {
        switch(deadActions)
        {
         case "InfectedByVirus":
              if(Pathogen != null)
              {
              Instantiate(Pathogen,transform.position, transform.rotation);
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
    public void OnTriggerEnter(Collider GermObject)
    {
        if(GermObject.gameObject.CompareTag("germ"))
        {
         Pathogen = GermObject.gameObject;
         breachedByGerm = true;
        }
    }
    public void OnTriggerExit(Collider GermObject)
    {
        if(GermObject.gameObject.CompareTag("germ"))
        {
         breachedByGerm = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Nucl"))
        {
            cellIsAlive = true;
        }
        else
        {
            cellIsAlive = false;
        }
    }
}
