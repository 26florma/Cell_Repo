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
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //checks to see if the player is in the bounds
            if (mousePos.y > corner1.transform.position.y)
            {
                Vector2 Newposition = Drone.transform.position;
                Newposition.y = corner1.transform.position.y -1;
                Drone.transform.position = Newposition;
                outOfBounds = false;
                
            }           
            if (mousePos.x > corner1.transform.position.x)
            {
                Vector2 Newposition = Drone.transform.position;
                Newposition.x = corner1.transform.position.x -1;
                Drone.transform.position = Newposition;
                outOfBounds = false;
                
            }
            if (mousePos.y < corner2.transform.position.y)
            {
                Vector2 Newposition = Drone.transform.position;
                Newposition.y = corner2.transform.position.y +1;
                Drone.transform.position = Newposition;
                outOfBounds = false;
                
            }
            if (mousePos.x < corner3.transform.position.x)
            {
                Vector2 Newposition = Drone.transform.position;
                Newposition.x = corner1.transform.position.x -1;
                Drone.transform.position = Newposition;
                outOfBounds = false;
                
            }
            if (mousePos.y < corner1.transform.position.y && mousePos.x > corner3.transform.position.x && mousePos.y > corner2.transform.position.y && mousePos.x < corner1.transform.position.y && outOfBounds == false)
            {
                outOfBounds = true;
                
            }
        }
    }
}
