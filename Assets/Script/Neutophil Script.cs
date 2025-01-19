using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutophilScript : MonoBehaviour
{
    public int neutrophilHP = 10;
    public int neutrophilD = 2;
    public int phagocytosisAttackSpeed = 5;
    public int toxinAttackSpeed = 10;
    public int netAttackSpeed =8;
    public int level = 1;
    public float neutrophilSpeed = 2;
    public float nearestDistance = 100000;
    public float distance;
    public bool onGerm = false;
    public bool selfStunned = false;
    bool isOnDelay = false;
    public string chosenAttacks;
    public float selfStunDelay =3;
    int Delay = 10;

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
        if (NearestGerm != null)
        {
            GermMovement germMovement = NearestGerm.gameObject.GetComponent<GermMovement>();
            if (germMovement.germHP <= 0)
            {
                germMovement.stunned = false;
                onGerm = false;
                Destroy(NearestGerm);
                NearestGerm = null;
                FindNearestGerm();
                StopCoroutine(startDelay());
                StopCoroutine(Phagocytosis());
            }
        }
        if (NearestGerm != null)
        {
            if (selfStunned == false)
            {
                Vector3 lookDirection = (NearestGerm.transform.position - transform.position).normalized;
                transform.Translate(lookDirection * Time.deltaTime * neutrophilSpeed, Space.World);
            }
            switch (chosenAttacks)
            {
                case "toxin":
                    StartCoroutine(Toxin());
                    break;
                case "nets":
                    StartCoroutine(Nets());
                    break;
                default:
                    StartCoroutine(Phagocytosis());
                    StartCoroutine(startDelay());
                    break;
            }
        }
        if (NearestGerm == null)
        {
            FindNearestGerm();
        }
        if (onGerm == true)
        {
            StartCoroutine(SelfStunningDelay());
            Debug.Log("running germ detection for selfstun");
        }
        else
        {
            selfStunned = false;
            Debug.Log("NOT running germ detection for selfstun");
        }
    }
        IEnumerator SelfStunningDelay()
        {
        yield return new WaitForSeconds(selfStunDelay);
        selfStunned= true;
        Debug.Log("Running selfstun");
        }
        public void FindNearestGerm()
        {
            AllGerms = GameObject.FindGameObjectsWithTag("germ");
            if (AllGerms.Length > 0)
            {
                nearestDistance = 100000;
                for (int i = 0; i < AllGerms.Length; i++)
                {
                    if (AllGerms[i] != null)
                    {
                        Vector3 targetGermPos = AllGerms[i].transform.position;
                        distance = Vector3.Distance(transform.position, targetGermPos);
                        if (distance < nearestDistance)
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
        while (isOnDelay == false && onGerm == true && NearestGerm != null)
        {
            yield return new WaitForSeconds(phagocytosisAttackSpeed);
            //phagocytosis
            isOnDelay = true;
            Debug.Log("running phagocytosis");
                GermMovement germMovement = NearestGerm.gameObject.GetComponent<GermMovement>();
                germMovement.germHP -= neutrophilD;
                germMovement.stunned = true;
                Delay = phagocytosisAttackSpeed;

            StopCoroutine(Phagocytosis());
        }
        }
        IEnumerator Toxin()
        {
        yield return new WaitForSeconds(toxinAttackSpeed);
        //toxicSpray
        if (level >= 2)
            {
            Debug.Log("Finish Later");
            }
        }
        IEnumerator Nets()
        {
            yield return new WaitForSeconds(netAttackSpeed);
            //nets
            if (level >= 3)
            {
                Debug.Log("finish later");
            }
        }
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("germ"))
            {
                onGerm = true;
                NearestGerm = collision.gameObject;
                
            }

        }
    IEnumerator startDelay()
    {
        while (isOnDelay == true)
        {
            yield return new WaitForSeconds(Delay);
            Debug.Log("running delay");
            isOnDelay = false;
        }
        
    }
}
