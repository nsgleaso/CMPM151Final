using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletSource;


    private void Start()
    {
        OSCHandler.Instance.Init();
    }
    // Update is called once per frame
    void Update()
    {
        //here is when I check if a certain beat is gonna
        //give me bullets
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var shot = Instantiate(bullet);
            shot.transform.position = bulletSource.transform.position;
            OSCHandler.Instance.SendMessageToClient("PD", "/sound/shoot", 1);
        }
    }
}
