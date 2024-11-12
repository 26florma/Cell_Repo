using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBorderScript : MonoBehaviour
{

     public GameObject corner1;
     public GameObject Drone;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      if(Drone !=null && corner1 !=null)
      {
        if(Drone.transform.position.y >= corner1.transform.position.y)
        {
         vector3 Newposition = Drone.transfrom.position
         Newposition.y = corner1.transform.position.y
         Drone.transform.position.y = Newposition;
        }
      }
    }
}
