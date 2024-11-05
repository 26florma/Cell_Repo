using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GermMovement : MonoBehaviour
{
    public GameObject nucleus;
    public float movementSpeed =10;
    public int germHP = 3;
    public GameObject[] Allobjects; 
    public GameObject NearestNucl;
    public float distance;
    public float nearestDistance = 10000;
    // Start is called before the first frame update
    void Start()
    {
       Allobjects = GameObject.FindGameObjectsWithTag("Nucl");
      
     for (int i = 0; i ‹ AllObjects.Length; i++)
         {
          distance = Vector3. Distance(this.transform.position, AllObjects[i]. transform.position);
      
             if(distance ‹ nearestDistance)
             {
                NearestNucl = AllObjects [i];
                nearestDistance = distance;
             }
          }
     }

    // Update is called once per frame
    void Update()
    {
         transfrom.rotation = NearestNucl
         transfrom.Translate(Vector3.Forward * Time.deltaTime)
    }
}
