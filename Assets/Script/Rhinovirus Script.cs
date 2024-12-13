using System.Collections;
using System.Collections.Generic;
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
        if(Cell != null && cellIsAlive == false)
        {
        Cell.deadActions = "InfectedByVirus";
        }
    }
    public void OnTriggerEnter2D(Collider CellObject)
    {
     If(CellObject.GameObject.CompareTag("Cell"))
     {
     CellObject = Cell
     }
    }
}
