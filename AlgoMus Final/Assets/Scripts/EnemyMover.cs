using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    private float speed;


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Recycler")
        {
            Debug.Log("hit recycler");
            EnemyPooler.Instance.AddPool(gameObject);
        }

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}
