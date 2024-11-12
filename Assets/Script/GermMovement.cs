using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GermMovement : MonoBehaviour
{
    public GameObject nucleus;
    public float movementSpeed =10;
    public int germHP = 3;
    public GameObject[] AllObjects; 
    public GameObject NearestNucl;
    public float distance;
    public float nearestDistance = 10000;
    public int germD = 1;
    public bool NuclAlive = false;
    private Rigidbody2D GermRb;

    // Start is called before the first frame update
    void Start()
    {
        GermRb = GetComponent<Rigidbody2D>();
        AllObjects = GameObject.FindGameObjectsWithTag("Nucl");
    }

    // Update is called once per frame
    void Update()
    {
      if(AllObjects != null)
        {
            NuclAlive = true;
        }
        if (NuclAlive = false)
        {
            Destroy(gameObject);
        }
      if(AllObjects != null)
      {
          for (int i = 0; i < AllObjects.Length; i++)
          {
                distance = Vector3.Distance(this.transform.position, AllObjects[i].transform.position);

                if (distance < nearestDistance)
                {
                    NearestNucl = AllObjects[i];
                    nearestDistance = distance;
                }
          }
          if(NearestNucl!= null && AllObjects != null)
          {
                Vector2 lookDirection = (NearestNucl.transform.position - transform.position).normalized;
                GermRb.AddForce(lookDirection * movementSpeed, ForceMode2D.Force);
          }
          
            
      }
        
    }

}
