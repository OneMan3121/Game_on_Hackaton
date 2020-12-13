using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCheker : MonoBehaviour
{
    public static float kick_force = 20; // tg(x/x) = 1 = 45 angle)

    public PlayerController playerController;
    private int PLAYER;
    public GameObject ball = null;


    // Start is called before the first frame update
    void Start()
    {
        PLAYER = playerController.PLAYER;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ball")
        {
            ball = other.gameObject;
            if (playerController.PLAYER == 3)
            {
                if (!playerController.isFaceisRight) ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-kick_force, kick_force), ForceMode2D.Impulse); // kick;
                else ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(kick_force, (float)(kick_force * System.Math.Sqrt(3))), ForceMode2D.Impulse); // tg (x * sqrt(3) / x ) = sqrt(3) ~ 60 angle)
            }
        }
    }
  
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ball")
        {
            ball = null;
        }
    }

    public void kickball() 
    {

        if (PLAYER == 1)
        {

            if (playerController.isFaceisRight) ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(kick_force, kick_force), ForceMode2D.Impulse); // kick;
            else ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-kick_force, (float)(kick_force * System.Math.Sqrt(3))), ForceMode2D.Impulse); // tg (x * sqrt(3) / x ) = sqrt(3) ~ 60 angle)
        }

        if (PLAYER == 2)
        {

            if (!playerController.isFaceisRight) ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-kick_force, kick_force), ForceMode2D.Impulse); // kick;
            else ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(kick_force, (float)(kick_force * System.Math.Sqrt(3))), ForceMode2D.Impulse); // tg (x * sqrt(3) / x ) = sqrt(3) ~ 60 angle)
        }


    }


}
