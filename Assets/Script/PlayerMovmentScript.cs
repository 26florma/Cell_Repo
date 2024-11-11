using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMomentScript : MonoBehaviour
{
    public int stemCells;
    public int damage = 1;
    public GameObject germ;
    public int stemCellBar;
    public int DNA;
    private bool collisionWithGerm;
    // Start is called before the first frame update
    void Start()
    {
        
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

            germ.GetComponent<GermMovement>().GermHP =- damage;
            
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
