using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDestroyer : MonoBehaviour
{

    public Transform playerX;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerX.position.x, -3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement.isAlive = false;
    }
}
