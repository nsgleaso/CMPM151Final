using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{


    public void Restart()
    {
        SceneManager.LoadScene(0);
        PlayerMovement.isAlive = true;
        GameController.GameIsRunning = true;
    }

    public void Exit()
    {
        Application.Quit();
    }


}
