using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsScript : MonoBehaviour
{

    public bool breachedByGerm = false;
    public bool cellIsAlive = true
    public string deadActions;  
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       if(cellIsALive = false)
       {
        Switch(deadActions)
        {
         case "InfectedByVirus":
              Debug.Log("Infected");
              break;
         case "KilledByPathogen":
              Debug.Log("Killed")
              break;
         default:
              Debug.Log("Error")
              break;
        }
       } 
       
    }
    public void OnTriggerEnter(Collider GermObject)
    {
        if(GermObject.gameObject.CompareTag("germ"))
        {
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
        if(collision.GameObject.CompareTag("Nucl"))
        {
         cellIsAlive = true
        }
        else
        {
         cellIsAlive = false
        }
    }
}
