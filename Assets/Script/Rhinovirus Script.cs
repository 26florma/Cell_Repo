using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RhinovirusScript : MonoBehaviour
{
    public GameObject Cell;
    public GameObject Nucl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Cell != null)
        {
            CellsScript cellScript = Cell.GetComponent<CellsScript>();
            if (Cell != null && Nucl == null)
            {
                cellScript.deadActions = "InfectedByVirus";
            }
        } 
    }
    public void OnTriggerEnter2D(Collider2D CellObject)
    {
     if(CellObject.gameObject.CompareTag("Nucl"))
     {
            Nucl = CellObject.gameObject;
     }
     if (CellObject.gameObject.CompareTag("Cell"))
     {
            Cell = CellObject.gameObject;
     }
    }
}