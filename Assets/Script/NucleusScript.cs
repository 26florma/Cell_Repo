using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class NucleusScript : MonoBehaviour
{
    public int NuclHP = 20;
    public List<GameObject> attackingGerm = new List<GameObject>();
    private bool hit = false;
    
    private GameObject germ;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      if(attackingGerm != null && attackingGerm.Count > 0)
      {
           foreach(GameObject germ in attackingGerm)
          {
            if(germ != null)
            {
              GermMovement germMovement = germ.GetComponent<GermMovement>();
              NuclHP -=germMovement.GermD;
            }
          } 
       
      }

        if(NuclHP <= 0)
        {
             Destroy(gameObject);
             if(attackingGerm.Count > 0)
             {
                GameObject AliveGerms = attackingGerm[0];
                if(AliveGerms != null)
                {
                germ.GetComponent<GermMovement>().NearestNucl = null;
                germ.GetComponent<GermMovement>().FindNearestObject();
                }
             }
        }

     }
    //detection for hit
    void OnTriggerEnter2D(Collider2D collision)
    {
     if(collision.gameObject.CompareTag("germ"))
     {
           if(!attackingGerm.Contains(collision.gameObject))
           {
              attackingGerm.Add(collision.gameObject);
           }

     }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
     if(collision.gameObject.CompareTag("germ"))
     {
              attackingGerm.Remove(collision.gameObject);
     }
    }
}
