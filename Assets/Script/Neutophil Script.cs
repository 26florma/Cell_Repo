using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutophilScript : MonoBehaviour
{
    public int neutophilHP = 10;
    public int neutophilD = 2;
    public float neutophilSpeed = 2;
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
    if(nearestGerm != null)
        {
        Vector3 lookdirection = (NearestGerm.transform.postition - transform.postition).normalize;
        transform.Translate(lookDirection * Time.delta.Time * neutophilSpeed, Space.World).normalize;
        NeutophilAttacks();
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
                vector3 targetGermPos = AllGerms[i].transform.position;
                distance = Vector3.Distance(transform.position,targetGermPos);
                    if(distance < neartestDistance)
                    {
                    neaestDistance = distance;
                    NearestGerm = AllGerms[i];
                    }
                }
            }
        }
    }
    public void NeutophilAttacks()
    {
    //phagocytosis
    if(onGerm == true)
    {
    GermMovement germMovement = collision.gameObject.GetComponent<GermMovement>();
    GermMovement.germHP -= neutophilD;
        if(GermMovement.germHP <= 0)
        {
        onGerm = false;
        Destroy(collision.gameObject);
        NearestGerm = null;
        FindNearestGerm();
        }
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
