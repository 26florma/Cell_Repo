using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMomentScript : MonoBehaviour
{
    public int stemCells;
    public int damage = 1;
    public GameObject germ;
    public int stemCellBar = 5;
    public int DNA;

    public GameObject borderScript;

    private int stemCellLimit;
    private bool collisionWithGerm;
    // Start is called before the first frame update
    void Start()
    {
        germ = GameObject.FindGameObjectWithTag("germ");
        borderScript = GameObject.FindGameObjectWithTag("border");
    }

    // Update is called once per frame
    void Update()
    {
        if(borderScript.GetComponent<GameBorderScript>().inBounds == true)
        {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && collisionWithGerm)
        {
            Debug.Log("Hit Detected");
            DNA =+ 1;

            germ.GetComponent<GermMovement>().germHP -= damage;
        }
        if (stemCellLimit == DNA)
        {
            stemCells =+ 1;
            DNA = 0;
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.CompareTag("germ"))
      {
            Debug.Log("collision detected");
            collisionWithGerm = true;
      }
      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("germ"))
        {
            collisionWithGerm = false;
        }

    }
}
