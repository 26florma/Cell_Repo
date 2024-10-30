using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GermMovement : MonoBehaviour
{
    public GameObject nucleus;
    public float movementSpeed =10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2.MoveTowards(transform.position, nucleus.transform.position, movementSpeed * Time.deltaTime);
    }
}
