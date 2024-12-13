using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GermMovement : MonoBehaviour
{

    public float movementSpeed =10;
    public float distance;
    public float nearestDistance = 10000;
    public int germHP = 3;
    public int germD = 1;
    public int germAttackSpeed = 10;
    public bool stunned = false;
    public List<GameObject> AllObjects new List<GameObject>(); 
    public GameObject NearestNucl;
    public GameObject Player;

    private GameObject Nucleus;
    // Start is called before the first frame update
    void Start()
    {
        FindNearestObject();
        AllObjects = GameObject.FindGameObjectsWithTag("Nucl").ToList();
        PlayerMovmentScript PlayerMovement = Player.GetComponent<PlayerMovmentScript>();
    }

    // Update is called once per frame
    void Update()
    {
         
         GermMovementFunction();
         if(NearestNucl == null)
         {
            FindNearestObject();
         }
         if(germHP <= 0)
         {
            Destroy(gameObject);
            PlayerMovement.TargetedGerm.Remove(this);
               if(Nucleus != null)
                {
                 NuclScript.attackingGerm.Remove(this);
                }
         }
    }
    public void GermMovementFunction()
    {//moves germ in the direction of nearest object
        if (NearestNucl != null && stunned == false)
        {
            Vector3 lookDirection = (NearestNucl.transform.position - transform.position).normalized;
            transform.Translate(lookDirection * Time.deltaTime * movementSpeed, Space.World);
            Debug.Log("Germ is moving");
        }
    }
    public void FindNearestObject()
    {
        //calculates the nearest objects distance from the germ

       AllObjects = GameObject.FindGameObjectsWithTag("Nucl");
        if (AllObjects.Count > 0)
        {
            nearestDistance = 10000f;
          
          for (int i = 0; i < AllObjects.Count; i++)
          {
           if (AllObjects[i] != null)
           {
             Vector3 targetPos = AllObjects[i].transform.position;
             distance = Vector3.Distance(transform.position,targetPos);

             if (distance < nearestDistance)
             {
              nearestDistance = distance;
              NearestNucl = AllObjects[i];

              Debug.Log("FindNearestObject is running");
             }
           }
         }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
    if(collision.gameObject.CompareTag("Nucl"))
    {
    NucleusScript NuclScript = Nucleus.GetComponent<NucleusScript>();
    collision.gameObject = Nucleus;
    }
    }
}
