using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public GameManager gameManager = null;
    public Transform pos_1;
    public ControllerManager controllerManager;
    public GameObject[] bonus;
    
    [HideInInspector]
    public GameObject player_1, player_2;

    void Start()
    {
        player_1 = gameManager.GetPlayer_1();
        player_2 = gameManager.GetPlayer_2();

        bonus[new System.Random().Next(0, bonus.Length - 1)].transform.position = pos_1.transform.position;




    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
