using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using Unity.VisualScripting;
using UnityEngine;

public class NucleusScript : MonoBehaviour
{
    public int NuclHP = 20;
    public bool germIsAttacking = false;
    public List<GameObject> attackingGerm = new List<GameObject>();

    private GameObject germ;

    // At the first frame runs the DamageDelay Coroutine
    void Start()
    {
      
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
                Destroy(gameObject);
                    if (AliveGerms.GetComponent<GermMovement>().NearestNucl == null)
                    {
                        
                        Debug.Log("Nucl is Dead");
                  
                    }
                    else
                    {
                        Debug.Log("Nucl is Dead didn't work");
                    }
                }
             }
        }
        if(germIsAttacking)
        {
         StartCoroutine(DamageDelay());
        }
    }
     Void OnDestroy()
    {
    GermMovement germMovement = germ.GetComponent<GermMovement>();
    germMovement.RemoveAllObjects(this);
    }
     IEnumerator DamageDelay()
     {
         GermMovement germMovement = germ.GetComponent<GermMovement>();
         while(attackingGerm.Count > 0)
         {
           yield return new WaitForSeconds(germMovement.germAttackSpeed);
           DealDamageToNucl();
           Debug.Log("Ran Damage cooldown");
         }
     }

     public void DealDamageToNucl()
     {
        GermMovement germMovement = germ.GetComponent<GermMovement>();
        if (attackingGerm.Count > 0)
        {
            foreach (GameObject germ in attackingGerm)
            {
                if (germ != null && germIsAttacking)
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
              germIsAttacking = true
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
             germIsAttacking = false
            }
     }
    }
}
