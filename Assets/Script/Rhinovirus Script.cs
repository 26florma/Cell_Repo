using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RhinovirusScript : MonoBehaviour
{
    public GameObject Cell;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Cell != null)
        {
            CellsScript CellScript = Cell.gameObject.GetComponent<CellsScript>();
            if (Cell != null && CellScript.cellIsAlive == false)
            {
                CellScript.deadActions = "InfectedByVirus";
            }
        } 
    }
    public void OnTriggerEnter2D(Collider2D CellObject)
    {
     if(CellObject.gameObject.CompareTag("Cell"))
     {
            Cell = CellObject.gameObject;
            CellsScript CellScript = Cell.gameObject.GetComponent<CellsScript>();
     }
    }
}