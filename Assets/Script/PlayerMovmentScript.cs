using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMomentScript : MonoBehaviour
{
    public int stemCells;
    public int damage = 1;
    public GameObject germs;
    public int stemCellBar;
    public int DNA;

    // Start is called before the first frame update
    void Start()
    {
        germs = GameObject.FindGameObjectWithTag("germ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.CompareTag("germ"))
      {
        Vector2 mousePos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Hit Detected");
            DNA = 1;
        }
      }
      
    }
}
