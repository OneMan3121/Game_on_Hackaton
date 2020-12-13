using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCheker : MonoBehaviour
{
    [HideInInspector]
    public bool isFloor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Floor")
        {
            isFloor = true;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Floor")
        {
            isFloor = false;
        }
    }
}
