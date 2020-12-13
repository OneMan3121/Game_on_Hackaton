using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rage : MonoBehaviour
{
    public GameObject[] fires;
    public GameManager gameManager;

    void Start()
    {
        disableRage();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.time_for_game < 60.0f) 
        {
            enableRage();
        }
        else disableRage();



    }
    void enableRage()
        {
        for (int i = 0; i < fires.Length; i++)
        {
            fires[i].SetActive(true);
        }
    }
        void disableRage()
        {
        for (int i = 0; i < fires.Length; i++)
        {
            fires[i].SetActive(false);
        }
    }




}
