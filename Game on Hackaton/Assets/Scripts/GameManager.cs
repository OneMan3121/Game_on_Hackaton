using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{



    public Transform spawnpoint_1 = null;
    public Transform spawnpoint_2 = null;
    public Transform spawnpoint_ball = null;

    public Text score_text = null;
    public Text timer_text = null;
    public float time_for_game = 60.0f;
    public GameObject PanelDeath = null;

    public GameObject[] prefubs = null;
    public GameObject prefub_ball = null;
    public SpriteRenderer[] prefubs_background = null;


    private int roundCount;
    private int p1_score,p2_score;
    private  int PlayerCount;
    private GameObject player_1, player_2;
    private GameObject ball;
    public static bool isGate_p1 = false;
    public static bool isGate_p2 = false;
    
    void Start()
    {
        p1_score = 0;
        p2_score = 0;
        PanelDeath.SetActive(false);
        prefubs_background[MainMenuManager.custom_background].color = new Color(1, 1, 1, 1);

        roundCount = MainMenuManager.roundCount;
        PlayerCount = MainMenuManager.playerCount;
        switch(PlayerCount)
        {
            case 1: // 1_vs_AI
                // player 1
                player_1 = Instantiate(prefubs[(MainMenuManager.p1_custom_character - 1)]);
                player_1.GetComponent<PlayerController>().SetPLAYER(1); // player 1

                //bot

                MainMenuManager.p2_custom_character = 1;
                Debug.Log("from 1 to " + prefubs.Length + " so  MainMenuManager.p2_custom_character = " + MainMenuManager.p2_custom_character);
                player_2 = Instantiate(prefubs[(MainMenuManager.p2_custom_character - 1)]);
                player_2.GetComponent<PlayerController>().SetPLAYER(3); // bot

                break;
            case 2: // 1_vs_1
                // player 1
                player_1 = Instantiate(prefubs[(MainMenuManager.p1_custom_character - 1)]);
                player_1.GetComponent<PlayerController>().SetPLAYER(1); // player 1

                // player 2
                player_2 = Instantiate(prefubs[(MainMenuManager.p2_custom_character - 1)]);
                player_2.GetComponent<PlayerController>().SetPLAYER(2); // player 2
                break;
            default:
                Debug.LogError("GameManager: PlayerCount = " + PlayerCount);
                break;
        }
        ball = Instantiate(prefub_ball);      

        startRound();

    }

    void startRound()
    {


        //player 1
        player_1.transform.position = spawnpoint_1.position;



        //player 2
        player_2.transform.position = spawnpoint_2.position;
        player_2.GetComponent<PlayerController>().flip();
        ball.GetComponent<Rigidbody2D>().gravityScale = 2;
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2();
        ball.transform.position = spawnpoint_ball.position;
    }

    void endround(int whoWin) // 1 - p1, 2 - p2, 3- end Time;
    {
        switch(whoWin)
        {
            case 1:
                p1_score++;
                isGate_p1 = false;
                score_text.text = p1_score + ":" + p2_score;
                if (p1_score == roundCount) endGame(1);

                startRound();


                break;

            case 2:
                p2_score++;
                isGate_p2 = false;
                score_text.text = p1_score + ":" + p2_score;
                if (p2_score == roundCount) endGame(2);

                startRound();

                break;

            case 3:
                if (p1_score > p2_score) endGame(1);
                if (p1_score < p2_score) endGame(2);
                if (p1_score == p2_score) endGame(3);
                break;

            default:
                Debug.LogError("GameManager: whoWin = " + whoWin);
                break;



        }
    }

    void endGame(int whoWin) // 1 - p1, 2 - p2, 3 - draw.
    {
        PanelDeath.SetActive(true);
        PanelDeath.GetComponent<DeathPanel>().preStart(whoWin);
        freezeAll();
        
    }

    public void freezeAll()
    {
        Rigidbody2D[] rigidbody2Ds = GameObject.FindObjectsOfType<Rigidbody2D>();
        for(int i = 0; i < rigidbody2Ds.Length; i++ )
        {
            rigidbody2Ds[i].simulated = false;
        }
    }
    public void unFreezeAll()
    {
        Rigidbody2D[] rigidbody2Ds = GameObject.FindObjectsOfType<Rigidbody2D>();
        for (int i = 0; i < rigidbody2Ds.Length; i++)
        {
            rigidbody2Ds[i].simulated = true;
        }
    }




    void FixedUpdate()
    {
        if (isGate_p1) endround(1);
        if (isGate_p2) endround(2);
    }

  


    // Update is called once per frame
    void Update()
    {
        time_for_game -= Time.deltaTime;
        int time_in_min = (int)System.Math.Floor(time_for_game / 60);
        int time_in_sec = (int)System.Math.Floor(time_for_game % 60);
        timer_text.text = time_in_min + " : " + time_in_sec;
        if (time_for_game < 0) endround(3);

    }

    public GameObject GetPlayer_1()
    {
        return player_1;
    }
    public GameObject GetPlayer_2()
    {
        return player_2;
    }
}
