using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCustom : MonoBehaviour
{
    public Text text_player;
    public RectTransform spawnpoint_character = null;
    public Button btn_left_background, btn_right_background, btn_left_character, btn_right_character;
    public Text text_btn_next = null;

    public Sprite[] backgrounds = null;
    private int backgroundCurrentIndex = 0;
    public Image currentBackGround = null;   
    public GameObject[] characters = null;
    private int characterCurrentIndex = 0;
    private GameObject currentCharacter;
    private bool isPlayerTwo = false;
    private bool isBackGraundElect = false;
    public void preStart() 
    {
        if (MainMenuManager.playerCount == 1) text_btn_next.text = "Почати гру!";
        else
        {
            isPlayerTwo = true;
            text_btn_next.text = "Наступний гравець";
        }
        changeBackGround();
        changeCharacter();
        CheckIndex();
    }


    public void leftBackground()
    {
        backgroundCurrentIndex--;
        changeBackGround();
        CheckIndex();
    }
    public void rightBackground()
    {
        backgroundCurrentIndex++;
        changeBackGround();
        CheckIndex();
    }
    public void leftCharacter()
    {
        characterCurrentIndex--;
        changeCharacter();
        CheckIndex();
    }
    public void rightCharacter()
    {
        characterCurrentIndex++;
        changeCharacter();
        CheckIndex();
    }

    void changeCharacter()
    {
        if (currentCharacter != null) Destroy(currentCharacter);
        currentCharacter = GameObject.Instantiate(characters[characterCurrentIndex]);
        currentCharacter.GetComponent<Rigidbody2D>().simulated = false;
        currentCharacter.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        currentCharacter.transform.position = spawnpoint_character.transform.position;

    }

    void changeBackGround()
    {
        currentBackGround.sprite = backgrounds[backgroundCurrentIndex];
    }

    public void CheckIndex()
    {
        if (!isBackGraundElect )
        {
            if (backgroundCurrentIndex == 0) btn_left_background.interactable = false;
            else btn_left_background.interactable = true;
            if (backgroundCurrentIndex == backgrounds.Length - 1) btn_right_background.interactable = false;
            else btn_right_background.interactable = true;
        } else
        {
            btn_left_background.interactable = false;
            btn_right_background.interactable = false;
        }

        if (characterCurrentIndex == 0) btn_left_character.interactable = false;
        else btn_left_character.interactable = true;
        if (characterCurrentIndex == characters.Length - 1) btn_right_character.interactable = false;
        else btn_right_character.interactable = true;
    }



    public void nextplayerOrStartGame()
    {
        if(isPlayerTwo)
        {
            text_btn_next.text = "Почати гру!";
            MainMenuManager.p1_custom_character = characterCurrentIndex+1;
            MainMenuManager.custom_background = backgroundCurrentIndex;
            characterCurrentIndex = 0;
            changeCharacter();
            isPlayerTwo = false;
            isBackGraundElect = true;
            CheckIndex();
            text_player.text = "2 Гравець";

        } else
        {
            if (MainMenuManager.playerCount != 1)
            {
                MainMenuManager.p2_custom_character = characterCurrentIndex+1;
                Initiate.Fade("GameScane", Color.black, 0.5f);
            } else
            {
                MainMenuManager.p1_custom_character = characterCurrentIndex+1;
                MainMenuManager.custom_background = backgroundCurrentIndex;
                isBackGraundElect = true;
                Initiate.Fade("GameScane", Color.black, 0.5f);
            }
        }
    }
}
