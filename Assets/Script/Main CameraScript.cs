using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{

    public GameObject Drone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Drone = null)
        {
            Vector2 cameraPos = transform.position;
            cameraPos.y = mousePos.y;
            cameraPos.x = mousePos.x;
        }
        
    }
}
