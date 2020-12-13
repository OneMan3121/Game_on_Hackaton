using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCustomPanel : MonoBehaviour
{
    public PanelCustom panelCustom;

    public void OnClick(string btn_name)
    {
        switch (btn_name)
        {
            case "left_background":
                panelCustom.leftBackground();
                break;
            case "right_background":
                panelCustom.rightBackground();
                break;
            case "left_character":
                panelCustom.leftCharacter();
                break;
            case "right_character":
                panelCustom.rightCharacter();
                break;
                
            case "btn_next":
                panelCustom.nextplayerOrStartGame();
                break;
            default:
                Debug.LogError("PanelCustom: btn_name = " + btn_name);
                break;
        }
    }
}
