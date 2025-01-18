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


    public GameObject Germ;

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
                }
             }
        }
        if(germIsAttacking)
        {
            StartCoroutine(GermDamageDelay());
        }
    }
     IEnumerator GermDamageDelay()
     {
        if (Germ != null)
        {
            GermMovement germMovement = Germ.GetComponent<GermMovement>();
            while (attackingGerm.Count > 0)
            {
                yield return new WaitForSeconds(germMovement.germAttackSpeed);
                DealDamageToNucl();

            }
        }
     }
    public void DealDamageToNucl()
    {
        if (Germ != null) 
        {
        GermMovement germMovement = Germ.GetComponent<GermMovement>();
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
     }
    //detection for hit
    void OnTriggerEnter2D(Collider2D collision)
    {
     if(collision.gameObject.CompareTag("germ"))
     {
           if(!attackingGerm.Contains(collision.gameObject))
           {
              attackingGerm.Add(collision.gameObject);
                germIsAttacking = true;
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
             germIsAttacking = false;
            }
     }
    }
}
