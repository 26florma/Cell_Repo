using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class NucleusScript : MonoBehaviour
{
    public int NuclHP = 20;
    
    private bool hit = false;
    
    private GameObject germ;
    
    // Start is called before the first frame update
    void Start()
    {
        germ = GameObject.FindGameObjectWithTag("germ");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(NuclHP <= 0)
        {
            Destroy(gameObject);
            germ.GetComponent<GermMovement>().NearestNucl = null;
        }
        if (hit == true)
        {
          NuclHP -= germ.GetComponent<GermMovement>().germD;
            Debug.Log("nucleus detected hit");
        }
    }
    //detection for hit
    void OnTriggerEnter2D(Collider2D collision)
    {
     if(collision.gameObject.CompareTag("germ"))
     {
            hit = true;
     }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
     if(collision.gameObject.CompareTag("germ"))
     {
            hit = false;
     }
    }
}
