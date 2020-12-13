using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnDeath : MonoBehaviour
{
    public GameManager gameManager;

    public void OnCLick(string btn_name)
    {
        switch(btn_name)
        {
            case "btn_endGame":
                Initiate.Fade("MainMenu", Color.black, 0.5f);
                break;
            case "btn_exitGame":
                Application.Quit();
                break;
            default:
               
                break;
        }
    }
}
