using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBorderScript : MonoBehaviour
{

     public GameObject corner1;
     public GameObject corner2
     public GameObject corner3;
     public GameObject Origin;   
     public GameObject Drone;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      //tests to see if all objects are assigned
      if(Drone !=null && corner1 !=null && corner2 !=null corner3 !=null corner4 !=null)
      {
        //checks to see if the player is in the bounds
        if(Drone.transform.position.y >= corner1.transform.position.y)
        {
         vector3 Newposition = Drone.transfrom.position
         Newposition.y = corner1.transform.position.y
         Drone.transform.position.y = Newposition;
        }
        if(Drone.transform.position.x >= corner1.transform.position.x)
        {
         vector3 Newposition = Drone.transfrom.position
         Newposition.x = corner1.transform.position.x
         Drone.transform.position.x = Newposition;
        }
        if(Drone.transform.position.y <= corner2.transform.position.y)
        {
         vector3 Newposition = Drone.transfrom.position
         Newposition.y = corner2.transform.position.y
         Drone.transform.position.y = Newposition;
        }
        if(Drone.transform.position.x <= corner3.transform.position.x)
        {
         vector3 Newposition = Drone.transfrom.position
         Newposition.x = corner3.transform.position.x
         Drone.transform.position.y = Newposition;
        }
      }
    }
}
