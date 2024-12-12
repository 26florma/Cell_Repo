using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsScript : MonoBehaviour
{

    public bool breachedByGerm = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
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
}
