using Spriter2UnityDX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour
{
    public Text winner;
    public Sprite[] backgrounds = null;
    public GameObject[] characters = null;
    public GameManager gameManager;
    public RectTransform spawnpoint_character = null;
    public Image currentBackGround = null;

    
    private GameObject currentCharacter;
    private int characterCurrentIndex = 0;
    private int backgroundCurrentIndex = 0;



    // Start is called before the first frame update
    public void preStart(int whoWin)
    {
       switch(whoWin)
        {
            case 1: // p1
                characterCurrentIndex = MainMenuManager.p1_custom_character;
                backgroundCurrentIndex = MainMenuManager.custom_background;
                winner.text = "1 Гравець переміг!";
                break;
            case 2: // p2
                characterCurrentIndex = MainMenuManager.p2_custom_character;
                backgroundCurrentIndex = MainMenuManager.custom_background;
                winner.text = "2 Гравець переміг!";
                break;
            case 3: // draw
                break;
                winner.text = "Нажаль ніхто не виграв(";
            default:
                Debug.LogError("DeathPanel: whoWin = " + whoWin);
                break;
        }
        changeBackGround();
        changeCharacter();
    }


    void changeBackGround()
    {
        currentBackGround.sprite = backgrounds[backgroundCurrentIndex];
    }
    void changeCharacter()
    {
        if (currentCharacter != null) Destroy(currentCharacter);
        currentCharacter = GameObject.Instantiate(characters[characterCurrentIndex-1]);
        
        currentCharacter.GetComponent<Rigidbody2D>().simulated = false;
        currentCharacter.GetComponent<EntityRenderer>().SortingOrder = 30;
        Destroy(currentCharacter.GetComponent<Animator>());
        
        currentCharacter.transform.position = spawnpoint_character.transform.position;

    }



}
