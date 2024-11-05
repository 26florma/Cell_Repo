using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GermMovement : MonoBehaviour
{
    public GameObject nucleus;
    public float movementSpeed =10;
    public int germHP = 3;
    public GameObject [] Allobjects; 
    public GameObject NearestOBJ;
    public float distance;
    public float nearestDistance = 10000;
    // Start is called before the first frame update
    void Start()
    {
      Allobjects = GameObject.FindGameObjectsWithTag("0B)");
      
      
     for (int i = 0; i ‹ AllObjects.Length; i++)
         {
          distance = Vector3. Distance(this.transform.position, AllObjects[i]. transform.position);
      
             if(distance ‹ nearestDistance)
             {
                NearestOB] = AllObjects [i];
                nearestDistance = distance;
             }
          }
     }

    // Update is called once per frame
    void Update()
    {
        Vector2.MoveTowards(transform.position, nucleus.transform.position, movementSpeed * Time.deltaTime);
    }
}
