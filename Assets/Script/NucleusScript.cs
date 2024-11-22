using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NucleusScript : MonoBehaviour
{
    public int NuclHP = 20;
    public List<GameObject> attackingGerm = new List<GameObject>();
    
    private GameObject germ;
    
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
      if(attackingGerm.Count > 0)
      {
           foreach(GameObject germ in attackingGerm)
          {
            if(germ != null)
            {
              GermMovement germMovement = germ.GetComponent<GermMovement>();
              NuclHP -=germMovement.germD;
            }
          } 
       
      }

        if(NuclHP <= 0)
        {
             
             if(attackingGerm.Count > 0)
             {
                GameObject AliveGerms = attackingGerm[0];
                if(AliveGerms != null)
                {
                AliveGerms.GetComponent<GermMovement>().NearestNucl = null;
                AliveGerms.GetComponent<GermMovement>().FindNearestObject();
                List = AliveGerms.GetComponent<GermMovement>().AllObjects;
                List.remove(GameObject)
                }
             }
          Destroy(gameObject);
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
            if(attackingGerm.Contains(collision.gameObject))
            {
             attackingGerm.Remove(collision.gameObject);
            }
     }
    }
}
