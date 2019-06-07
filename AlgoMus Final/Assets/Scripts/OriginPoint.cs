using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 20, transform.position.y);
    }
}
