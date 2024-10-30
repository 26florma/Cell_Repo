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
    private bool isOnGerm;

    // Start is called before the first frame update
    void Start()
    {
        germs = GameObject.FindGameObjectWithTag("germ");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        if (Input.GetKeyDown(KeyCode.Mouse0) && isOnGerm == true)
        {
            Debug.Log("Hit Detected");
            DNA = 1;
        }
        if(DNA > stemCellBar)
        {
            isOnGerm= false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.CompareTag("germ"))
      {
            isOnGerm = true;
      }
      
    }
}
