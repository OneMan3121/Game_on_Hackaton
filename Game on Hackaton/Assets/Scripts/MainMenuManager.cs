using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private bool isStartPressed = false;

    public static GameObject btn_Start, btn_Setting, btn_1_vs_AI, btn_1_vs_1, btn_Exit, Panel_Setting;

    void Start()
    {
        if(btn_Start == null) btn_Start = GameObject.Find("Btn_Start"); // Start
        if (btn_Setting == null) btn_Setting = GameObject.Find("Btn_Setting"); // Setting
        if (btn_1_vs_AI == null) // 1_vs_AI
        {
            btn_1_vs_AI = GameObject.Find("Btn_Game_1_vs_AI");
            btn_1_vs_AI.SetActive(false);
        }
        if (btn_1_vs_1 == null) // 1_vs_1
        {
            btn_1_vs_1 = GameObject.Find("Btn_Game_1_vs_1");
            btn_1_vs_1.SetActive(false);
        }
           
        if (btn_Exit == null) btn_Exit = GameObject.Find("Btn_Exit"); // Exit
        if (Panel_Setting == null) // Panel Setting
        {
            Panel_Setting = GameObject.Find("Panel_Setting");
            Panel_Setting.SetActive(false);
        }
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
                btn_1_vs_AI.SetActive(btn_Start.GetComponent<Toggle>().isOn);
                btn_1_vs_1.SetActive(btn_Start.GetComponent<Toggle>().isOn);
                
                break;
            case "Setting":
                Panel_Setting.SetActive(btn_Setting.GetComponent<Toggle>().isOn);
                if (btn_Start.GetComponent<Toggle>().isOn) OnClick("Start");
                break;
            case "1_vs_AI":
                break;
                break;
            case "1_vs_1":
                break;
            case "Exit":
                Application.Quit();
                break;
            default:
                Debug.LogError("MainMenuManager: can't find button: " + btn_name + "please fix me!");
                break;
        }
    }










}
