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

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        myRigidBody2D.velocity = new Vector2(horizontalMovement * speed, myRigidBody2D.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(checkPosition.position, checkRadius, layer);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            verticalMovement = Input.GetAxis("Vertical");
            verticalMovement = Mathf.Clamp(verticalMovement, 0f, 0.05f);
            if(myRigidBody2D.velocity.y == 0)
            {
                myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, verticalMovement * jumpForce);
                Debug.Log(myRigidBody2D.velocity.y);
            }
            
        }
        
    }
}
