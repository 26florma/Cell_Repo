using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using Unity.VisualScripting;
using UnityEngine;

public class NucleusScript : MonoBehaviour
{
    public int NuclHP = 20;
    public List<GameObject> attackingGerm = new List<GameObject>();

   
    private GameObject germ;

    // At the first frame runs the DamageDelay Coroutine
    void Start()
    {
      StartCoroutine(DamageDelay());
    }

    void Update()
    {
        //kills Nucl
        if(NuclHP <= 0)
        {
            Debug.Log("DeadNucl is Running");
             if(attackingGerm.Count > 0)
             {
                GameObject AliveGerms = attackingGerm[0];
                if(AliveGerms != null)
                {
                
                AliveGerms.GetComponent<GermMovement>().NearestNucl = null;
                AliveGerms.GetComponent<GermMovement>().FindNearestObject();
                
                    if(AliveGerms.GetComponent<GermMovement>().NearestNucl == null)
                    {
                        Destroy(gameObject);
                        Debug.Log("Nucl is Dead");
                  
                    }
                    else
                    {
                        Debug.Log("Nucl is Dead didn't work");
                    }
           
                }

             }
        }
        
    }
     IEnumerator DamageDelay()
     {
         GermMovement germMovement = germ.GetComponent<GermMovement>();
         while(attackingGerm.Count > 0)
         {
           yield return new WaitForSeconds(germMovement.germAttackSpeed);
           DealDamageToNucl();
         }
     }

     public void DealDamageToNucl()
     {
        GermMovement germMovement = germ.GetComponent<GermMovement>();
        if (attackingGerm.Count > 0)
        {
            foreach (GameObject germ in attackingGerm)
            {
                if (germ != null)
                {
                    NuclHP -= germMovement.germD;
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
            if(attackingGerm.Contains(collision.gameObject))
            {
             attackingGerm.Remove(collision.gameObject);
            }
     }
    }
}
