using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMomentScript : MonoBehaviour
{
    public int stemCells;
    public int damage = 1;
    public GameObject germs;
    private int germHP;
    public int stemCellBar;
    public int DNA;
    private bool collisionWithGerm;
    // Start is called before the first frame update
    void Start()
    {
        germs = GameObject.FindGameObjectWithTag("germ");
        germHP = GetComponent<GermMovement>().germHP;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && collisionWithGerm)
        {
            Debug.Log("Hit Detected");
            DNA = 1;
            germHP = -damage;
            
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
