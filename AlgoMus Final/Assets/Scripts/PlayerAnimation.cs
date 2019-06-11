using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Rigidbody2D myRigidBody2D;
    private Animator myAnim;

    private bool playedDA = false;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playedDA)
        {
            return;
        }
        if(PlayerMovement.isAlive == false)
        {
            myAnim.Play("PlayerDeath");
            playedDA = true;
            GameController.GameIsRunning = false;
        }

        
        if(myRigidBody2D.velocity.x > 0)
        {
            myAnim.SetBool("isRunning", true);
        }
        else
        {
            myAnim.SetBool("isRunning", false);
        }
    }
}
