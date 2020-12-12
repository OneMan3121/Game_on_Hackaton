using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private bool isStartPressed = false;

    public static Button btn_Start, btn_Setting, btn_1_vs_AI, btn_1_vs_1, btn_Exit;
    void Start()
    {
        btn_Start = GameObject.Find("Btn_Start").GetComponent<Button>();
        btn_Setting = GameObject.Find("Btn_Setting").GetComponent<Button>();
        btn_1_vs_AI = GameObject.Find("Btn_Game_1_vs_AI").GetComponent<Button>();
        btn_1_vs_1 = GameObject.Find("Btn_Game_1_vs_1").GetComponent<Button>();
        btn_Exit = GameObject.Find("Btn_Exit").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(string btn_name)
    {
        Debug.Log("Button" + btn_name + " pressed!");
        switch (btn_name)
        {
            case "Start":
                if(isStartPressed)
                {
                    isStartPressed = !isStartPressed;
                    btn_1_vs_AI.enabled = true;
                    btn_1_vs_1.enabled = true;
                } else
                {
                    isStartPressed = !isStartPressed;
                    btn_1_vs_AI.enabled = false;
                    btn_1_vs_1.enabled = false;
                }
                break;
            case "Setting":
                break;
            case "1_vs_AI":
                break;
                break;
            case "1_vs_1":
                break;
            case "Exit":
                break;
            default:
                Debug.LogError("MainMenuManager: can't find button: " + btn_name + "please fix me!");
                break;
        }
    }










}
