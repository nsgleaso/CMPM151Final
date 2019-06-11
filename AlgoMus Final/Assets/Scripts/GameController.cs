using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static bool GameIsRunning;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        GameIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameIsRunning == false)
        {
            canvas.gameObject.SetActive(true);
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
