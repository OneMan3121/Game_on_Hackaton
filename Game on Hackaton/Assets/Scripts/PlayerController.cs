using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int PLAYER = 1;

    [HideInInspector]
    public bool isFaceisRight = true;
    
    
    public FloorCheker florCheker = null;
    public BallCheker ballCheker = null;
    private Animator animator;
    private Rigidbody2D rigidbody;
    private GameObject BallforBot;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        BallforBot = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (rigidbody.velocity.x > 0.3f && !isFaceisRight) flip();
        else if (rigidbody.velocity.x < -0.3f && isFaceisRight) flip();
        switch (PLAYER)
        {
            case 1: // PLayer 1
                animator.SetBool("isKicked", ControllerManager.p1_isKick);
                if (ControllerManager.p1_isKick && ballCheker.ball != null) ballCheker.kickball();
                animator.SetFloat("Ox_velocrity", System.Math.Abs(ControllerManager.p1_Ox_speed));
                rigidbody.velocity = new Vector2(ControllerManager.p1_Ox_speed, rigidbody.velocity.y); // left, right
                if (florCheker.isFloor) rigidbody.AddForce(new Vector2(0, ControllerManager.p1_Oy_jump_force), ForceMode2D.Impulse); // jump;


                break;
            case 2: // Player 2 
                animator.SetBool("isKicked", ControllerManager.p2_isKick);
                if (ControllerManager.p2_isKick && ballCheker.ball != null) ballCheker.kickball();
                animator.SetFloat("Ox_velocrity", System.Math.Abs(ControllerManager.p2_Ox_speed));
                rigidbody.velocity = new Vector2(ControllerManager.p2_Ox_speed, rigidbody.velocity.y); // left, right
                if (florCheker.isFloor) rigidbody.AddForce(new Vector2(0, ControllerManager.p2_Oy_jump_force), ForceMode2D.Impulse); // jump;
                break;
            case 3: // Bot
                animator.SetBool("isKicked", ControllerManager.p2_isKick);
                if (BallforBot.transform.position.x - gameObject.transform.position.x < -4)
                {
                    rigidbody.velocity = new Vector2(-ControllerManager.p2_Ox_speed, rigidbody.velocity.y);
                    animator.SetFloat("Ox_velocrity", System.Math.Abs(ControllerManager.p2_Ox_speed));
                } else
                if (gameObject.transform.position.x - BallforBot.transform.position.x > 4)
                {
                    rigidbody.velocity = new Vector2(ControllerManager.p2_Ox_speed, rigidbody.velocity.y);
                    animator.SetFloat("Ox_velocrity", System.Math.Abs(ControllerManager.p2_Ox_speed));
                } else
                {
                    animator.SetFloat("Ox_velocrity", 0);
                }
                



        break;

        default:
                Debug.LogError("PlayerController: PLAYER = " + PLAYER);
        break;
    


        }
    }

    public void flip()
    {
        isFaceisRight = !isFaceisRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
    
    public void SetPLAYER(int value)
    {
        PLAYER = value;
    }

}
