using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidBody2D;

    [SerializeField]
    private float verticalMovement;

    //horizontal movement variables
    [SerializeField]
    private float speed;
    private float horizontalMovement;

    //jump related variables
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private LayerMask layer;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private Transform checkPosition;


    public static bool isAlive = true;
    private float timerDeath;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        OSCHandler.Instance.Init();
        OSCHandler.Instance.SendMessageToClient("PD", "/sound/theme/on", 1);

        isAlive = true;
    }

    private void FixedUpdate()
    {
        if (isAlive == false)
        {
            return;
        }
        horizontalMovement = Input.GetAxis("Horizontal");
        myRigidBody2D.velocity = new Vector2(horizontalMovement * speed, myRigidBody2D.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive == false)
        {
            timerDeath += Time.deltaTime;
        }
        if(timerDeath > 1)
        {
            KillPlayer();
            return;
        }
        isGrounded = Physics2D.OverlapCircle(checkPosition.position, checkRadius, layer);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            verticalMovement = Input.GetAxis("Vertical");
            verticalMovement = Mathf.Clamp(verticalMovement, 0f, 0.05f);
            if(myRigidBody2D.velocity.y == 0)
            {
                myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, verticalMovement * jumpForce);
            }
            
        }
        
    }

    private void KillPlayer()
    {
        
        //OSCHandler.Instance.SendMessageToClient("PD", "/sound/theme/off", 2);
        OSCHandler.Instance.SendMessageToClient("PD", "/sound/enemy/distance", 0);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "OneNote" ||
            collision.gameObject.tag == "TwoNote")
        {
            OSCHandler.Instance.SendMessageToClient("PD", "/sound/reload", 1);
            isAlive = false;
        }
    }
}
