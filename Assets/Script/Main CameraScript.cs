using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public Transform cameraPos;
    public Transform drone;
    public float cameraDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Drone = null)
        {
           cameraPos.Position = drone.Position + new Vector3(cameraDistance,5,0);
        }
        
    }
}
