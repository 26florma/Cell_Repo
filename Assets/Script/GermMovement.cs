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
    public GameObject[] AllObjects; 
    public GameObject NearestNucl;
    public GameObject nucleus;



    // Start is called before the first frame update
    void Start()
    {
        FindNearestObject();
    }

    // Update is called once per frame
    void Update()
    {
          //moves germ in the direction of nearest object
          if(NearestNucl!= null)
          {
                Vector3 lookDirection = (NearestNucl.transform.position - transform.position).normalized;
                transform.Translate( lookDirection * Time.deltaTime * movementSpeed, Space.World);
                Debug.Log("Germ is moving");
          }  
    }
    public void FindNearestObject()
    {
        //calculates the nearest objects distance from the germ
        
        AllObjects = GameObject.FindGameObjectsWithTag("Nucl");
        if (AllObjects.Length > 0)
        {
            nearestDistance = 10000f;
          
          for (int i = 0; i < AllObjects.Length; i++)
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
    
}
