using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameBorderScript : MonoBehaviour
{

     public GameObject corner1;
     public GameObject corner2;
     public GameObject corner3;
     public GameObject Origin;   
     public GameObject Drone;
     public bool outOfBounds = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //tests to see if all objects are assigned
        if (Drone != null && corner1 != null && corner2 != null && corner3 != null && Origin != null)
        {
            //checks to see if the player is in the bounds
            if (Drone.transform.position.y > corner1.transform.position.y)
            {
                Vector2 Newposition = Drone.transform.position;
                Newposition.y = corner1.transform.position.y;
                Drone.transform.position = Newposition;
                outOfBounds = false;
                Debug.Log("detected y");
            }
            if (Drone.transform.position.y < corner1.transform.position.y && outOfBounds = false)
            {
                outOfBounds = true;
                Debug.Log("In bounds");
            }
            if (Drone.transform.position.x > corner1.transform.position.x)
            {
                Vector2 Newposition = Drone.transform.position;
                Newposition.x = corner1.transform.position.x;
                Drone.transform.position = Newposition;
                outOfBounds = false;
                Debug.Log("detected x");
            }
            if (Drone.transform.position.x < corner1.transform.position.y && outOfBounds = false)
            {
                outOfBounds = true;
                Debug.Log("In bounds");
            }
            if (Drone.transform.position.y < corner2.transform.position.y)
            {
                Vector2 Newposition = Drone.transform.position;
                Newposition.y = corner2.transform.position.y;
                Drone.transform.position = Newposition;
                outOfBounds = false;
                Debug.Log("detected y");
            }
            if (Drone.transform.position.y > corner2.transform.position.y && outOfBounds = false)
            {
                outOfBounds = true;
                Debug.Log("In bounds");
            }
            if (Drone.transform.position.x > corner3.transform.position.x)
            {
                Vector2 Newposition = Drone.transform.position;
                Newposition.x = corner3.transform.position.x;
                Drone.transform.position = Newposition;
                outOfBounds = false;
                Debug.Log("detected x");
            }
            if (Drone.transform.position.x < corner3.transform.position.x && outOfBounds = false)
            {
                outOfBounds = true;
                Debug.Log("In bounds");
            }
        }
    }
}
