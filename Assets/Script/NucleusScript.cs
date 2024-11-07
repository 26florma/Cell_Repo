using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleusScript : MonoBehaviour
{
    public int NuclHP = 20;
    private bool NuclDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(NuclDead == true) 
        {
            Destroy(gameObject);
        }
    }
}
