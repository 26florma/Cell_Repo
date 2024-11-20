using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
     GameObject cameraPos;
     Transform drone;
     float cameraDistance;
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = GameObject.FindGameObjectWithTag("PlayerCamera");
    }

    // Update is called once per frame
    void Update()
    {
       
        if (drone = null)
        {
           cameraPos.transform.position = drone.position + new Vector3(cameraDistance, 5, 0);
        }
        
    }
}
