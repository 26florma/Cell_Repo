using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutophilScript : MonoBehaviour
{
    public int neutrophilHP = 10;
    public int neutrophilD = 2;
    public int phagocytosisAttackSpeed = 5;
    public float neutrophilSpeed = 2;
    public float nearestDistance = 100000;
    public float distance;
    public bool onGerm = false;
    
    public GameObject[] AllGerms;
    public GameObject NearestGerm;
    public GameObject germ;
    // Start is called before the first frame update
    void Start()
    {
      FindNearestGerm();
    }
    
    // Update is called once per frame
    void Update()
    {
    if(NearestGerm != null)
        {
        Vector3 lookDirection = (NearestGerm.transform.position - transform.position).normalized;
        transform.Translate(lookDirection * Time.deltaTime * neutrophilSpeed, Space.World);
        if(onGerm == true)
        {
        StartCoroutine(Phagocytosis());
        }
        }
    }
    public void FindNearestGerm()
    {
    AllGerms = GameObject.FindGameObjectsWithTag("germ");
        if(AllGerms.Length > 0)
        {
            nearestDistance = 100000;
            for(int i = 0; i < AllGerms.Length; i++)
            {
                if(AllGerms[i] != null)
                {
                Vector3 targetGermPos = AllGerms[i].transform.position;
                distance = Vector3.Distance(transform.position,targetGermPos);
                    if(distance < nearestDistance)
                    {
                    nearestDistance = distance;
                    NearestGerm = AllGerms[i];
                    }
                }
            }
        }
        else
        {
        NearestGerm = null;
        }
    }
    IEnumerator Phagocytosis()
    {
    yield return new WaitForSeconds(phagocytosisAttackSpeed);
    //phagocytosis
    if(onGerm == true)
    {
    GermMovement germMovement = NearestGerm.gameObject.GetComponent<GermMovement>();
    germMovement.germHP -= neutrophilD;
    germMovement.stunned = true;
        if(germMovement.germHP <= 0)
        {
        NearestGerm.stunned = false;
        onGerm = false;
        Destroy(NearestGerm);
        NearestGerm = null;
        FindNearestGerm();
        }
    }
    }
    IEnumerator Toxin()
    public void NeutrophilAttacks()
    {
     yield return new WaitForSeconds(toxinAttackSpeed);
    if(Level >= 2)
    {
    
    
    }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("germ"))
        {
        onGerm = true;
        NearestGerm = collision.gameObject;
        }
    }
}
