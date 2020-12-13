using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedu : MonoBehaviour
{
    public BonusManager bonusManager;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            bonusManager.controllerManager.players_speed_Ox += 10;
            Destroy(this.gameObject);
        }
    }
}
