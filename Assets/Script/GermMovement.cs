using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GermMovement : MonoBehaviour
{
    public float movementSpeed = 10;
    public float distance;
    public float nearestDistance = 10000;
    public int germHP = 3;
    public int germD = 1;
    public int germAttackSpeed = 10;
    public int selfStunDelay = 3;
    public bool stunned = false;
    public List<GameObject> AllObjects = new List<GameObject>();
    public GameObject NearestNucl;
    public GameObject Player;
    public GameObject Goal;
    public int aggression = 10;

    private bool moveTowardsGoal = true;
    private GameObject Nucleus;
    private GameObject Neutrophil;
    // Start is called before the first frame update
    void Start()
    {
        
        AllObjects = GameObject.FindGameObjectsWithTag("Nucl").ToList();
        Player = GameObject.FindGameObjectWithTag("Drone");
        Goal = GameObject.FindGameObjectWithTag("Goal");
    }
    // Update is called once per frame
    void Update()
    {
        aggression = UnityEngine.Random.Range(0, aggression);
        if (aggression == 0)
        {
            moveTowardsGoal = false;
            FindNearestObject();
        }
        else
        {
            moveTowardsGoal = true;
        }
        if (stunned == false)
        {
            GermMovementFunction();
        }
        if (NearestNucl == null && moveTowardsGoal == false)
        {
            FindNearestObject();
        }
        if (germHP <= 0)
        {
            Destroy(gameObject);
            if (Nucleus != null)
            {
                NucleusScript NuclScript = Nucleus.GetComponent<NucleusScript>();
                NuclScript.attackingGerm.Remove(gameObject);
            }
        }
    }
    public void GermMovementFunction()
    {//moves germ in the direction of nearest object or moves towards goal
        if (NearestNucl != null && moveTowardsGoal == false)
        {
            Vector3 lookDirection = (NearestNucl.transform.position - transform.position).normalized;
            transform.Translate(lookDirection * Time.deltaTime * movementSpeed, Space.World);
            Debug.Log("Germ is moving to cell");
        }
        else
        {
            Vector3 lookDirection = (Goal.transform.position - transform.position).normalized;
            transform.Translate(lookDirection * Time.deltaTime * movementSpeed, Space.World);
            Debug.Log("Germ is moving to goal");
        }
    }
    public void FindNearestObject()
    {//calculates the nearest objects distance from the germ
        AllObjects = GameObject.FindGameObjectsWithTag("Nucl").ToList();
        if (AllObjects.Count > 0)
        {
            nearestDistance = 10000f;

            for (int i = 0; i < AllObjects.Count; i++)
            {
                if (AllObjects[i] != null)
                {
                    Vector3 targetPos = AllObjects[i].transform.position;
                    distance = Vector3.Distance(transform.position, targetPos);

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
        if (collision.gameObject.CompareTag("Nucl") || collision.gameObject.CompareTag("Goal"))
        {
            Nucleus = collision.gameObject;
            NucleusScript NuclScript = Nucleus.GetComponent<NucleusScript>();
            StartCoroutine(SelfStunningDelay());
        }

        if (collision.gameObject.CompareTag("Neutrophil"))
        {
            Neutrophil = collision.gameObject;
            NeutophilScript NeutScript = Neutrophil.GetComponent<NeutophilScript>();
            stunned = true;
        }
    }
    IEnumerator SelfStunningDelay()
    {
        yield return new WaitForSeconds(selfStunDelay);
        stunned = true;
    }
}
