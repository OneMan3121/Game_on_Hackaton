using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGatePlayer_1 = false; // true - isGate_p1 false - isGate_p2

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ball")
        {
            if (isGatePlayer_1) GameManager.isGate_p1 = true;
            else GameManager.isGate_p2 = true;
        }
    }

}
