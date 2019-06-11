using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int health;

    private void Start()
    {
        if(gameObject.tag == "OneNote")
        {
            health = 1;
        }
        else
        {
            health = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed;

        //if enemy dies, put it back in the queue
        if(health == 0)
        {
            EnemyPooler.Instance.AddPool(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Recycler")
        {
            EnemyPooler.Instance.AddPool(gameObject);
        }else if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Got hit");
            --health;
        }

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}
