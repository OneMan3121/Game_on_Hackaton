using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{

    public float players_speed_Ox = 1.0f;
    public float players_jump_force_Oy = 1.0f;

    public static float p1_Ox_speed = 0.0f;
    public static float p1_Oy_jump_force = 0.0f;
    public static bool p1_isKick = false;
    public static float p2_Ox_speed = 0.0f;
    public static float p2_Oy_jump_force = 0.0f;
    public static bool p2_isKick = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player 1

        if (Input.GetKey(KeyCode.A)) p1_Ox_speed = players_speed_Ox * (-1);
        else 
        if (Input.GetKey(KeyCode.D)) p1_Ox_speed = players_speed_Ox * 1;
        else p1_Ox_speed = 0;
        if (Input.GetKeyDown(KeyCode.W)) p1_Oy_jump_force = players_jump_force_Oy * 1;
        else p1_Oy_jump_force = 0;
        if (Input.GetKeyDown(KeyCode.LeftShift)) p1_isKick = true;
        else p1_isKick = false;

        // Player 2
        if (MainMenuManager.playerCount == 2)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) p2_Ox_speed = players_speed_Ox * (-1);
            else
            if (Input.GetKey(KeyCode.RightArrow)) p2_Ox_speed = players_speed_Ox * 1;
            else p2_Ox_speed = 0;
            if (Input.GetKeyDown(KeyCode.UpArrow)) p2_Oy_jump_force = players_jump_force_Oy * 1;
            else p2_Oy_jump_force = 0;
            if (Input.GetKeyDown(KeyCode.RightShift)) p2_isKick = true;
            else p2_isKick = false;
        } else
        {
            p2_Ox_speed = players_speed_Ox;

        }


    }

    void FixedUpdate()
    {

    }
}
