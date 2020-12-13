using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSlow : MonoBehaviour
{
    public BonusManager bonusManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            bonusManager.controllerManager.players_speed_Ox = 4;
            Destroy(this.gameObject);
        }
    }
}
